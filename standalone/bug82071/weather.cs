using System.Diagnostics;
using System.Xml.Serialization;
using System;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Web.Services;

[DebuggerStepThroughAttribute ()]
[DesignerCategoryAttribute ("code")]
[System.Web.Services.WebServiceBindingAttribute (Name = "ndfdXMLBinding", Namespace = "http://www.weather.gov/forecasts/xml/DWMLgen/wsdl/ndfdXML.wsdl")]
public class WeatherForcecastService : System.Web.Services.Protocols.SoapHttpClientProtocol
{
	public WeatherForcecastService ()
	{
		this.Url = "http://www.weather.gov/forecasts/xml/SOAP_server/ndfdXMLserver.php";
	}

	[System.Web.Services.Protocols.SoapRpcMethodAttribute ("http://www.weather.gov/forecasts/xml/DWMLgen/wsdl/ndfdXML.wsdl#NDFDgen", RequestNamespace = "http://www.weather.gov/forecasts/xml/DWMLgen/wsdl/ndfdXML.wsdl", ResponseNamespace = "http://www.weather.gov/forecasts/xml/DWMLgen/wsdl/ndfdXML.wsdl")]
	[return: System.Xml.Serialization.SoapElementAttribute ("dwmlOut")]
	public string NDFDgen (System.Decimal latitude, System.Decimal longitude, productType product, System.DateTime startTime, System.DateTime endTime, weatherParametersType weatherParameters)
	{
		object [] results = this.Invoke ("NDFDgen", new object [] {
			latitude,
			longitude,
			product,
			startTime,
			endTime,
			weatherParameters});
		return ((string) (results [0]));
	}

	public System.IAsyncResult BeginNDFDgen (System.Decimal latitude, System.Decimal longitude, productType product, System.DateTime startTime, System.DateTime endTime, weatherParametersType weatherParameters, System.AsyncCallback callback, object asyncState)
	{
		return this.BeginInvoke ("NDFDgen", new object [] {
			latitude,
			longitude,
			product,
			startTime,
			endTime,
			weatherParameters}, callback, asyncState);
	}

	public string EndNDFDgen (System.IAsyncResult asyncResult)
	{
		object [] results = this.EndInvoke (asyncResult);
		return ((string) (results [0]));
	}

	[System.Web.Services.Protocols.SoapRpcMethodAttribute ("http://www.weather.gov/forecasts/xml/DWMLgen/wsdl/ndfdXML.wsdl#NDFDgenByDay", RequestNamespace = "http://www.weather.gov/forecasts/xml/DWMLgen/wsdl/ndfdXML.wsdl", ResponseNamespace = "http://www.weather.gov/forecasts/xml/DWMLgen/wsdl/ndfdXML.wsdl")]
	[return: System.Xml.Serialization.SoapElementAttribute ("dwmlByDayOut")]
	public string NDFDgenByDay (System.Decimal latitude, System.Decimal longitude, [System.Xml.Serialization.SoapElementAttribute (DataType = "date")] System.DateTime startDate, [System.Xml.Serialization.SoapElementAttribute (DataType = "integer")] string numDays, formatType format)
	{
		object [] results = this.Invoke ("NDFDgenByDay", new object [] {
			latitude,
			longitude,
			startDate,
			numDays,
			format});
		return ((string) (results [0]));
	}

	public System.IAsyncResult BeginNDFDgenByDay (System.Decimal latitude, System.Decimal longitude, System.DateTime startDate, string numDays, formatType format, System.AsyncCallback callback, object asyncState)
	{
		return this.BeginInvoke ("NDFDgenByDay", new object [] {
			latitude,
			longitude,
			startDate,
			numDays,
			format}, callback, asyncState);
	}

	public string EndNDFDgenByDay (System.IAsyncResult asyncResult)
	{
		object [] results = this.EndInvoke (asyncResult);
		return ((string) (results [0]));
	}
}

[System.Xml.Serialization.SoapTypeAttribute ("productType", "http://www.weather.gov/forecasts/xml/DWMLgen/schema/DWML.xsd")]
public enum productType
{
	[System.Xml.Serialization.SoapEnumAttribute ("time-series")]
	timeseries,

	glance,
}

[System.Xml.Serialization.SoapTypeAttribute ("weatherParametersType", "http://www.weather.gov/forecasts/xml/DWMLgen/schema/DWML.xsd")]
public class weatherParametersType
{
	public bool maxt;
	public bool mint;
	public bool temp;
	public bool dew;
	public bool pop12;
	public bool qpf;
	public bool sky;
	public bool snow;
	public bool wspd;
	public bool wdir;
	public bool wx;
	public bool waveh;
	public bool icons;
	public bool rh;
	public bool appt;
	public bool incw34;
	public bool incw50;
	public bool incw64;
	public bool cumw34;
	public bool cumw50;
	public bool cumw64;
	public bool wgust;
	public bool conhazo;
	public bool ptornado;
	public bool phail;
	public bool ptstmwinds;
	public bool pxtornado;
	public bool pxhail;
	public bool pxtstmwinds;
	public bool ptotsvrtstm;
	public bool pxtotsvrtstm;
}

[System.Xml.Serialization.SoapTypeAttribute ("formatType", "http://www.weather.gov/forecasts/xml/DWMLgen/schema/DWML.xsd")]
public enum formatType
{
	[System.Xml.Serialization.SoapEnumAttribute ("24 hourly")]
	Item24hourly,

	[System.Xml.Serialization.SoapEnumAttribute ("12 hourly")]
	Item12hourly,
}
