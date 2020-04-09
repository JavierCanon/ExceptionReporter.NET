using System;
using Bugsnag.Payload;
using Xunit;

namespace Bugsnag.Tests.Payload
{
  public class ReportTests
  {
    [Fact]
    public void ContainsTheRequiredKeys()
    {
      var configuration = new Configuration("123456");
      var exception = new DllNotFoundException();
      var severity = HandledState.ForUnhandledException();
      var breadcrumbs = new Breadcrumb[0];
      var session = new Session();

      var @event = new Report(configuration, exception, severity, breadcrumbs, session);

      Assert.Equal(configuration.ApiKey, @event["apiKey"]);
      Assert.NotNull(@event["notifier"]);
      Assert.NotNull(@event["events"]);
    }

    [Fact]
    public void LargePaylaodsDropBreadcrumbsAndMetadata()
    {
      var configuration = new Configuration("123456");
      var exception = new DllNotFoundException();
      var severity = HandledState.ForUnhandledException();
      var breadcrumbs = new Breadcrumb[] { new Breadcrumb("wow bread!", BreadcrumbType.Manual) };
      var session = new Session();

      var report = new Report(configuration, exception, severity, breadcrumbs, session);

      report.Event.Metadata.Add("small metadat", "so small");
      report.Event.Metadata.Add("large metadata", new String('a', (1024 * 1024)));

      var data = report.Serialize();

      Assert.NotNull(data);

      Assert.Null(report.Event.Breadcrumbs);
      Assert.Single(report.Event.Metadata);
    }
  }
}
