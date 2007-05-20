// BaseReflectionDocumenterConfig.cs - base XML documenter config class
// Copyright (C) 2004  Kevin Downs
// Parts Copyright (C) 2001  Kral Ferch, Jason Diamond
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA

using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing.Design;
using System.Reflection;
using System.Windows.Forms.Design;
using System.Xml;

public class DocumenterConfig
{
	private ReferencePathCollection _referencePaths;
	private bool _showMissingSummaries;
	private SdkLanguage _sdkDocLanguage = SdkLanguage.en;

	public DocumenterConfig ()
	{
		_referencePaths = new ReferencePathCollection ();
		_showMissingSummaries = true;
	}

	[Category ("(Global)")]
	[Description ("A collection of additional paths to search for reference assemblies.\nNote: This is a PROJECT level property that is shared by all documenters...")]
	public ReferencePathCollection ReferencePaths {
		get {
			return _referencePaths;
		}
		set {
			_referencePaths = value;
		}
	}

	[Category ("Show Missing Documentation")]
	[Description ("Turning this flag on will show you where you are missing summaries.")]
	[DefaultValue (true)]
	public bool ShowMissingSummaries {
		get {
			return _showMissingSummaries;
		}
		set {
			_showMissingSummaries = value;
		}
	}

	[Category ("Documentation Main Settings")]
	[Description ("Specifies to which Language version of the .NET Framework SDK documentation the links to system types will be pointing.")]
	[DefaultValue (SdkLanguage.en)]
	[System.ComponentModel.TypeConverter (typeof (EnumDescriptionConverter))]
	public SdkLanguage SdkDocLanguage {
		get {
			return _sdkDocLanguage;
		}
		set {
			_sdkDocLanguage = value;
		}
	}
}

public enum SdkLanguage
{
	[Description ("English")]
	en,
	[Description ("French")]
	fr,
	[Description ("German")]
	de,
	[Description ("Italian")]
	it,
	[Description ("Japanese")]
	ja,
	[Description ("Korean")]
	ko,
	[Description ("Spanish")]
	es
}
