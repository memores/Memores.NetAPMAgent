# Memores.Metrics
Metrics for .Net reporting to ElasticSearch
## Memores.Metrics.Wcf
### Description
This project contains some metrics for WCF services with reporting results to ElasticSearch with Grafana visualization.
### How to use
Add to web.config behavior extension element
```xml
  <system.serviceModel>
    <extensions>
      <behaviorExtensions>
        <add name="elasticEndpointBehavior" type=" Memores.Metrics.Wcf.ExtentionElements.EndpointBehaviorExtentionElement, Memores.Metrics.Wcf, Version=1.0.0.0, Culture=neutral"/>        
      </behaviorExtensions>
    </extensions>
    ...
  </system.serviceModel>
```
Add behavior with ElasticSearch settings such as host, port and index name
```xml
    <behaviors>
      <endpointBehaviors>
        <behavior>
          <elasticEndpointBehavior hostname="http://localhost" port="9200" index="wcfsample" />
        </behavior>
      </endpointBehaviors>
    </behaviors>
```
Start your service and make requests.
### Visualization
Import to your Grafana dashboard from https://github.com/memores/Memores.Metrics/tree/master/visualization
Add data source and setup it in dashboard
