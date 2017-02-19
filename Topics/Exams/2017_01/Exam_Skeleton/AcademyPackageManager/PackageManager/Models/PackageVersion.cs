using PackageManager.Models.Contracts;
using PackageManager.Enums;
using System;

namespace PackageManager.Models
{
    public class PackageVersion : IVersion
    {
        private int major;
        private int minor;
        private int patch;
        private VersionType versionType;

        public PackageVersion(int major, int minor, int patch, VersionType type)
        {
            this.Major = major;
            this.Minor = minor;
            this.Patch = patch;
            this.VersionType = type;
        }

        public int Major
        {
            get
            {
                return this.major;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }

                this.major = value;
            }
        }

        public int Minor
        {
            get
            {
                return this.minor;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }

                this.minor = value;
            }
        }
        public int Patch
        {
            get
            {
                return this.patch;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }

                this.patch = value;
            }
        }

        public VersionType VersionType
        {
            get
            {
                return this.versionType;
            }
            private set
            {
                if(!Enum.IsDefined(typeof(VersionType), value))
                {
                    throw new ArgumentException();
                }

                this.versionType = value;
            }
        }
    }
}
