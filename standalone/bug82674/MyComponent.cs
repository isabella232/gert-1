using System;
using System.Drawing;

namespace Mono.Tests
{
	public class MyComponent
	{
		public MyComponent (string title, string zone)
		{
			_title = title;
			_zone = zone;
		}

		public Image BackgroundImage
		{
			get { return _backgroundImage; }
			set { _backgroundImage = value; }
		}

		public int Interval
		{
			get { return _interval; }
			set { _interval = value; }
		}

		public bool Localizable
		{
			get { return _localizable; }
			set { _localizable = value; }
		}

		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		public string Text
		{
			get { return "Mono"; }
		}

		public string Title
		{
			get { return _title; }
			set { _title = value; }
		}

		public string Zone
		{
			get { return _zone; }
			set { _zone = value; }
		}

		public string Company
		{
			get { return _company; }
			set { _company = value; }
		}

		private Image _backgroundImage;
		private string _company;
		private int _interval;
		private bool _localizable;
		private string _name;
		private string _title;
		private string _zone;
	}
}
