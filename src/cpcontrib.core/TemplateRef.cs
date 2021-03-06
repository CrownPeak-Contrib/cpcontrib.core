﻿//!packer:targetFile=lib.cs
using System;

//!packer:sortOrder=999;region=AssetRef/TemplateRef/IAssetRef
namespace CrownPeak.CMSAPI.CustomLibrary
{

	/// <summary>
	/// Interface for consolidating of TemplateRef and AssetRef
	/// </summary>
	public interface IAssetRef
	{
		/// <summary>
		/// Gets the Path for this IAssetRef instance
		/// </summary>
		string Path { get; }
		/// <summary>
		/// Gets the Id for this IAssetRef instance
		/// </summary>
		int Id { get; }
	}

	/// <summary>
	/// Provides a reference to a CrownPeak Template.
	/// </summary>
	public class TemplateRef : IAssetRef
	{

		public TemplateRef(string assetPath, int templateId)
		{
			this._AssetPath = assetPath;
			this._TemplateId = templateId;
		}

		string _AssetPath;
		int _TemplateId;

		public string AssetPath
		{
			get { return this._AssetPath; }
		}

		/// <summary>
		/// The TemplateId or AssetId of the Template.
		/// </summary>
		public int TemplateId
		{
			get { return this._TemplateId; }
		}

		[Obsolete("Best to directly specify TemplateId or AssetPath or other.")]
		public static implicit operator int(TemplateRef value)
		{
			return value.TemplateId;
		}

#region IAssetRef members
		string IAssetRef.Path { get { return this.AssetPath; } }
		int IAssetRef.Id { get { return this.TemplateId; } }
#endregion


	}

		/// <summary>
	/// Provides a reference to a CrownPeak Asset.
	/// </summary>
	public class AssetRef : IAssetRef
	{

		public AssetRef(string assetPath, int id)
		{
			this._AssetPath = new AssetPath(assetPath);
			this._Id = id;
		}

		AssetPath _AssetPath;
		int _Id;

		public AssetPath AssetPath
		{
			get { return this._AssetPath; }
		}

		/// <summary>
		/// The TemplateId or AssetId of the Template.
		/// </summary>
		public int Id
		{
			get { return this._Id; }
		}

		string IAssetRef.Path { get { return this.AssetPath.ToString(); } }


	}

}
//!packer:endregion
