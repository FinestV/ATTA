using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Optimization;
using Examine;
using ImageProcessor;
using ImageProcessor.Imaging;
using Umbraco.Core;
using Umbraco.Core.Configuration;
using Umbraco.Core.Configuration.UmbracoSettings;
using Umbraco.Core.IO;
using Umbraco.Core.Models;
using Umbraco.Core.Services;

namespace ATTA.Web
{
    public class ApplicationEvents : ApplicationEventHandler
    {
        protected override void ApplicationStarting(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            //Register bundles
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //Resize images max width: 2400px
            ResizeImageOnSave(2400);
        }

        //protected override void ApplicationStarted(UmbracoApplicationBase app, ApplicationContext ctx)
        //{
        //    //Index all content to a shared field
        //    ExamineManager.Instance
        //                  .IndexProviderCollection["ExternalIndexer"]
        //                  .GatheringNodeData += OnGatheringNodeData;
        //}

        //protected void OnGatheringNodeData(object sender, IndexingNodeDataEventArgs e)
        //{
        //    var builder = new StringBuilder();
        //    foreach (var entry in e.Fields)
        //    {
        //        builder.AppendFormat("{0}, ", entry.Value);
        //    }

        //    e.Fields.Add("combinedText", builder.ToString());
        //}

        private static void ResizeImageOnSave(int maxwidth)
        {
            // Tap into the Saving event
            MediaService.Saving += (sender, args) =>
            {
                MediaFileSystem mediaFileSystem = FileSystemProviderManager.Current.GetFileSystemProvider<MediaFileSystem>();
                IContentSection contentSection = UmbracoConfig.For.UmbracoSettings().Content;
                IEnumerable<string> supportedTypes = contentSection.ImageFileTypes.ToList();

                foreach (IMedia media in args.SavedEntities)
                {
                    if (media.HasProperty("umbracoFile"))
                    {
                        // Make sure it's an image.
                        string path = media.GetValue<string>("umbracoFile");
                        var s = Path.GetExtension(path);
                        if (s != null)
                        {
                            string extension = s.Substring(1);
                            if (supportedTypes.InvariantContains(extension))
                            {
                                // Resize the image to 1920px wide, height is driven by the
                                // aspect ratio of the image.
                                string fullPath = mediaFileSystem.GetFullPath(path);
                                using (ImageFactory imageFactory = new ImageFactory(true))
                                {
                                    ResizeLayer layer = new ResizeLayer(new Size(maxwidth, 0), ResizeMode.Max)
                                    {
                                        Upscale = false
                                    };

                                    imageFactory.Load(fullPath)
                                        .Resize(layer)
                                        .Save(fullPath);
                                }
                            }
                        }
                    }
                }
            };
        }
    }
}