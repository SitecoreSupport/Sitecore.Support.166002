namespace Sitecore.Support.Mvc.Pipelines.Response.RenderPlaceholder
{
    using Sitecore.Mvc.Pipelines.Response.RenderPlaceholder;
    using Sitecore.Mvc.Presentation;
    using System.IO;

    public class PerformRendering : Sitecore.Mvc.Pipelines.Response.RenderPlaceholder.PerformRendering
    {
        protected override void Render(string placeholderName, TextWriter writer, RenderPlaceholderArgs args)
        {
            foreach (Rendering rendering in this.GetRenderings(placeholderName, args))
            {
                if (rendering != null && rendering.Renderer != null)
                {
                    using (this.CreateCyclePreventer(placeholderName, rendering))
                    {
                        this.ProcessRenderRendering(rendering, writer);
                    }
                }
            }
        }
    }
}
