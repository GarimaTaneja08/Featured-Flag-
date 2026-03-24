
//Enable a feature (e.g., discount) only during a specific date/time range

public class HomeController : Controller
{

    private readonly IFeatureManager _featureManager;

    public HomeController(IFeatureManager featureManager)
    {
        _featureManager = featureManager;
    }

    public async Task<IActionResult> Discount()
    {
        if (await _featureManager.IsEnabledAsync("DiscountFeature"))
        {
            return Content("Discount is LIVE!");
        }

        return Content("Discount expired or not started yet.");
    }
}



/*Real-world Example
Imagine:
Big Sale from 25 March → 31 March 
No manual code change needed 
No redeploy needed 
For “valid period” logic in .NET feature flags:
Use TimeWindow filter 
No need to write custom date-check logic 

*/