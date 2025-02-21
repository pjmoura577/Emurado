﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Http;
using HaloOnline.Server.Model.TitleResource;
using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Controllers
{
    [RoutePrefix("TitleResourceService.svc")]
    public class GetTitleResourceController : ApiController
    {

        private const string Advertisement = "ADVERTISMENT.json";
        private const string UiDesc = "UI_DESC.json";
        private const string News = "NEWS.json";
        private const string Playlist = "PLAYLIST.json";
        private const string Weapon = "WEAPON.json";
        private const string Color = "COLOR.json";
        private const string Grenade = "GRENADE.json";
        private const string Consumable = "CONSUMABLE.json";
        private const string ConsUiStats = "CONS_UI_STATS.json";
        private const string WpnUiStats = "WPN_UI_STATS.json";

        [HttpPost]
        [Route("GetTitleConfiguration")]
        public IHttpActionResult GetTitleResource()
        {
            try
            {
                string solutionDirectory = SolutionDirectoryGetter.GetSolutionDirectory();

                string instancesFolder = Path.Combine(solutionDirectory, "HaloOnline.Server.Core.Http\\Controllers\\instances");
                string advertisementPath = Path.Combine(instancesFolder, Advertisement);
                string uiDescPath = Path.Combine(instancesFolder, UiDesc);
                string newsPath = Path.Combine(instancesFolder, News);
                string playlistPath = Path.Combine(instancesFolder, Playlist);
                string weaponPath = Path.Combine(instancesFolder, Weapon);
                string ColorPath = Path.Combine(instancesFolder, Color);
                string grenadePath = Path.Combine(instancesFolder, Grenade);
                string consumablePath = Path.Combine(instancesFolder, Consumable);
                string consuistatsPath = Path.Combine(instancesFolder, ConsUiStats);
                string wpnuistatsPath = Path.Combine(instancesFolder, WpnUiStats);


                string advertisementJsonContent = File.ReadAllText(advertisementPath);
                var advertisementInstances = JsonConvert.DeserializeObject<List<dynamic>>(advertisementJsonContent);

                string uiDescJsonContent = File.ReadAllText(uiDescPath);
                var uiDescInstances = JsonConvert.DeserializeObject<List<dynamic>>(uiDescJsonContent);

                string newsJsonContent = File.ReadAllText(newsPath);
                var newsInstances = JsonConvert.DeserializeObject<List<dynamic>>(newsJsonContent);

                string weaponJsonContent = File.ReadAllText(weaponPath);
                var weaponInstances = JsonConvert.DeserializeObject<List<dynamic>>(weaponJsonContent);

                string playlistJsonContent = File.ReadAllText(playlistPath);
                var playlistInstances = JsonConvert.DeserializeObject<List<dynamic>>(playlistJsonContent);

                string colorJsonContent = File.ReadAllText(ColorPath);
                var colorInstances = JsonConvert.DeserializeObject<List<dynamic>>(colorJsonContent);

                string grenadeJsonContent = File.ReadAllText(grenadePath);
                var grenadeInstances = JsonConvert.DeserializeObject<List<dynamic>>(grenadeJsonContent);

                string consumableJsonContent = File.ReadAllText(consumablePath);
                var consumableInstances = JsonConvert.DeserializeObject<List<dynamic>>(consumableJsonContent);

                string consuistatsJsonContent = File.ReadAllText(consuistatsPath);
                var consuistatsInstances = JsonConvert.DeserializeObject<List<dynamic>>(consuistatsJsonContent);

                string wpnuistatsJsonContent = File.ReadAllText(wpnuistatsPath);
                var wpnuistatsInstances = JsonConvert.DeserializeObject<List<dynamic>>(wpnuistatsJsonContent);

                var combinedInstances = new List<dynamic>();
                combinedInstances.AddRange(advertisementInstances);
                combinedInstances.AddRange(uiDescInstances);
                combinedInstances.AddRange(newsInstances);
                combinedInstances.AddRange(weaponInstances);
                combinedInstances.AddRange(playlistInstances);
                combinedInstances.AddRange(colorInstances);
                combinedInstances.AddRange(grenadeInstances);
                combinedInstances.AddRange(consumableInstances);
                combinedInstances.AddRange(consuistatsInstances);
                combinedInstances.AddRange(wpnuistatsInstances);

                var response = new
                {
                    GetTitleConfigurationResult = new
                    {
                        retCode = 0,
                        data = new
                        {
                            combinationHash = "",
                            instances = combinedInstances
                        }
                    }
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
