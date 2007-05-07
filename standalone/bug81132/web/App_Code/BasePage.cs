using System;
using System.Web.UI;

public class BasePage : Page
{
	private string _value = "DEFAULT";
	private MyEnum _myEnum;

	public BasePage ()
	{
	}

	public string CustomValue {
		get {
			return _value;
		}
		set {
			_value = value;
		}
	}

	public MyEnum MyEnum {
		get {
			return _myEnum;
		}
		set {
			_myEnum = value;
		}
	}
}
