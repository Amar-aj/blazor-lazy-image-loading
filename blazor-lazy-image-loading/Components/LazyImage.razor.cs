using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace blazor_lazy_image_loading.Components;

public partial class LazyImage
{
    [Parameter]
    public string ImageUrl { get; set; }

    [Parameter]
    public int Width { get; set; }

    [Parameter]
    public int Height { get; set; }

    [Parameter]
    public string Alt { get; set; }

    [Parameter]
    public string CssClass { get; set; }

    private ElementReference imageRef;

    [Inject]
    IJSRuntime JSRuntime { get; set; }

    private async void LoadImage()
    {
        var src = await JSRuntime.InvokeAsync<string>("Interop.setImage", imageRef, ImageUrl);
    }
    private void OnError()
    {
        Console.WriteLine("Error loading image");
    }
}
