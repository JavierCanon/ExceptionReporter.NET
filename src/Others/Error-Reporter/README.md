# Error-Reporter
My custom error reporting class library. I've used this in several projects to quickly give me some valuable information to try and debug issues. Having the data object model that caused the problem is extremely beneficial. 


# How to use
Currently you'll add the class library to your project. Create a ErrorReportSettings class (You can load these values from a json file if you want, I've created a template for this)
Pass this object into the ErrorReporter. Optionally you can add telemetry client using application insights. 
If you have a sendgrid api key in the settings it will spin up the send grid provider and send your errors via email.
