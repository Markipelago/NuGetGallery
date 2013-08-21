﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace NuGetGallery
{
    public class EditPackageVersionRequest
    {
        public EditPackageVersionRequest()
        {
        }

        public EditPackageVersionRequest(Package package, PackageEdit pendingMetadata)
        {
            PackageId = package.PackageRegistration.Id;
            PackageTitle = package.Title;
            Version = package.Version;
            HasPendingMetadata = (pendingMetadata != null);

            var metadata = pendingMetadata ?? new PackageEdit
            {
                Authors = package.FlattenedAuthors,
                Copyright = package.Copyright,
                Description = package.Description,
                IconUrl = package.IconUrl,
                LicenseUrl = package.LicenseUrl,
                ProjectUrl = package.ProjectUrl,
                ReleaseNotes = package.ReleaseNotes,
                RequiresLicenseAcceptance = package.RequiresLicenseAcceptance,
                Summary = package.Summary,
                Tags = package.Tags,
                Title = package.Title,
            };
            Authors = metadata.Authors;
            Copyright = metadata.Copyright;
            Description = metadata.Description;
            IconUrl = metadata.IconUrl;
            LicenseUrl = metadata.LicenseUrl;
            ProjectUrl = metadata.ProjectUrl;
            ReleaseNotes = metadata.ReleaseNotes;
            RequiresLicenseAcceptance = metadata.RequiresLicenseAcceptance;
            Summary = metadata.Summary;
            Tags = metadata.Tags;
            VersionTitle = metadata.Title;
        }

        // Not part of the client edit request, just used for rendering the view
        public string LicenseUrl { get; set; }
        public string PackageId { get; set; }
        public string PackageTitle { get; set; }
        public string Version { get; set; }
        public bool HasPendingMetadata { get; set; }
        public IList<Package> PackageVersions { get; set; }


        [StringLength(256)]
        [Display(Name = "Title")]
        [DataType(DataType.Text)]
        public string VersionTitle { get; set; } // not naming it Title in our model because that would clash with page Title in the property bag. Blech.

        [StringLength(256)]
        [Display(Name = "Icon URL")]
        [DataType(DataType.ImageUrl)]
        [RegularExpression(Constants.UrlValidationRegEx, ErrorMessage = Constants.UrlValidationErrorMessage)]
        public string IconUrl { get; set; }

        [StringLength(1024)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Summary (shown in package search results)")]
        public string Summary { get; set; }

        [StringLength(4000)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        [Required]
        public string Description { get; set; }

        [StringLength(256)]
        [Display(Name = "Project Home Page URL")]
        [DataType(DataType.Text)]
        [RegularExpression(Constants.UrlValidationRegEx, ErrorMessage = Constants.UrlValidationErrorMessage)]
        public string ProjectUrl { get; set; }

        [StringLength(512)]
        [Display(Name = "Authors (comma-separated list - e.g. 'Anna, Bob, Carl')")]
        [DataType(DataType.Text)]
        [Required]
        public string Authors { get; set; }

        [StringLength(512)]
        [Display(Name = "Copyright")]
        [DataType(DataType.Text)]
        public string Copyright { get; set; }

        [StringLength(1024)]
        [DataType(DataType.Text)]
        [Display(Name = "Tags (space-separated list - e.g. 'ASP.NET Templates MVC)")]
        public string Tags { get; set; }

        [Display(Name = "Release Notes (for this version)")]
        [DataType(DataType.MultilineText)]
        public string ReleaseNotes { get; set; }

        [Display(Name = "Requires license acceptance")]
        public bool RequiresLicenseAcceptance { get; set; }
    }
}
