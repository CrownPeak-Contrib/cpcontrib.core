﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrownPeak.CMSAPI.Custom_Library
{

	/// <summary>
	/// Helps with links generated by LinkHelper and by the Component Framework.core.Href and Component Framework.core.LinkAndTarget 
	/// </summary>
	public class CPLink
	{
		public CPLink(CrownPeak.CMSAPI.PanelEntry panel, string baseName)
		{
			_Panel = panel;
			_BaseName = baseName;
		}

		private PanelEntry _Panel;
		private string _BaseName;

		public string GetHref()
		{
			string href;

			if(_Panel.Raw[_BaseName + "_link_type"] == "External")
			{
				href = _Panel.Raw[_BaseName + "_link_external"];
				return href;
			}
			else
			{
				var asset = _GetTargetAsset();
				href = asset.GetLink();
				return href;
			}
		}


		private Asset _GetTargetAsset()
		{
			var asset = Asset.Load(_Panel.Raw["upload#" + _BaseName + "_link_internal"]);
			return asset;
		}



	}

}
