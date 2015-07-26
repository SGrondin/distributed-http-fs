﻿using System;
using System.IO;

namespace httpfsc.Business.Http
{
    public sealed class Url
    {
        #region Fields

        private readonly string _url;

        #endregion

        #region Constructors

        public Url(string url)
        {
            this._url = url;
        }

        #endregion

        #region Operators

        public static implicit operator string(Url url)
        {
            return url._url;
        }

        public static implicit operator Url(string url)
        {
            return new Url(url);
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return this._url;
        }

        public Url Combine(Url url)
        {
            if (url == null || url == "/" || url == "\\")
            {
                return this;
            }

            return Path.Combine(this._url, url._url.TrimStart('/'));
        }

        public Url GetDirectoryName()
        {
            return Path.GetDirectoryName(this);
        }

        public Url FullPath
        {
            get
            {
                return Path.GetFullPath(this);
            }
        }

        public string FileName
        {
            get
            {
                return Path.GetFileName(this);
            }
        }

        public bool IsDirectory
        {
            get
            {
                return File.GetAttributes(this).HasFlag(FileAttributes.Directory);
            }
        }

        #endregion
    }
}