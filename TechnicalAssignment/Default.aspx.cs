using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Threading;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using TechnicalAssignment.Models;
using System.Diagnostics;

namespace TechnicalAssignment
{
    public partial class _Default : Page
    {
        static string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };
        static string ApplicationName = "TestSpreadsheet";
        AssetsModel context = new AssetsModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
            try
            {
                UserCredential credential;
                using (var stream =
                       new FileStream(Server.MapPath("/client_secret_16116874541-dj07ma6bnimk8fpmrqpdj7lruvnfs6ec.apps.googleusercontent.com.json"), FileMode.Open, FileAccess.Read))
                {
                    string credPath = Server.MapPath("/token.json");
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.FromStream(stream).Secrets,
                        Scopes,
                        "user",
                        CancellationToken.None,
                        new FileDataStore(credPath, true)).Result;
                }

                var service = new SheetsService(new BaseClientService.Initializer
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName
                });

                String spreadsheetId = "1YCqc8fKP3y9FHNb70O-GPWFqZK7Hqh_e8T2IKQirD2E";
                String range = "sheet1!A2:E";
                SpreadsheetsResource.ValuesResource.GetRequest request =
                    service.Spreadsheets.Values.Get(spreadsheetId, range);

                ValueRange response = request.Execute();
                IList<IList<Object>> values = response.Values;
                if (values == null || values.Count == 0)
                {
                    Debug.WriteLine("No data found");
                    return;
                }
                foreach (var row in values)
                {
                        string assetId = row[0].ToString();
                        string assetName = row[1].ToString();
                        string modelNumber = row[2].ToString();
                        string vendor = row[3].ToString();
                        string description = row[4].ToString();
                    context.Assets.Add(new Asset {AssetId= assetId, AssetName= assetName, ModelNumber= modelNumber, Vendor= vendor, Description= description });
                }
                  context.SaveChanges();
            }
            catch (FileNotFoundException ex)
            {
                Debug.WriteLine(ex.Message);
            }
            }

        }
    }
}