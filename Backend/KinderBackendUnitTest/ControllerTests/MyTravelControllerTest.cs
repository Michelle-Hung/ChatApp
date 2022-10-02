using System;
using System.Collections.Generic;
using System.Text.Json;
using Kinder_Backend.Controllers;
using Kinder_Backend.Models;
using NUnit.Framework;

namespace KinderBackendUnitTest;

[TestFixture]
public class MyTravelControllerTest
{
    private MyTravelController _myTravelController;

    [SetUp]
    public void Setup()
    {
        _myTravelController = new MyTravelController();
    }

    [Test]
    public void get_travel_list_should_success()
    {
        var actual = _myTravelController.Get();
        var expected = new TravelResponse(){
                TravelList = new List<TravelList>{
                    new TravelList{
                    Id = 1,
                    Attraction = "淡水老街",
                    StartDate = new DateTime(2021, 9, 27),
                    PictureName = "Wuling.jpeg"
                },

                new TravelList{
                    Id = 2,
                    Attraction = "The Twelve Apostles",
                    StartDate = new DateTime(2021, 9, 27),
                    PictureName = "Wuling.jpeg"
                },new TravelList{
                    Id = 3,
                    Attraction = "The Twelve Apostles",
                    StartDate = new DateTime(2021, 9, 27),
                    PictureName = "Wuling.jpeg"
                },new TravelList{
                    Id = 4,
                    Attraction = "The Twelve Apostles",
                    StartDate = new DateTime(2021, 9, 27),
                    PictureName = "Wuling.jpeg"
                },new TravelList{
                    Id = 5,
                    Attraction = "The Twelve Apostles",
                    StartDate = new DateTime(2021, 9, 27),
                    PictureName = "Wuling.jpeg"
                },new TravelList{
                    Id = 6,
                    Attraction = "The Twelve Apostles",
                    StartDate = new DateTime(2021, 9, 27),
                    PictureName = "Wuling.jpeg"
                },
            }
        };

        Assert.AreEqual(JsonSerializer.Serialize(expected), JsonSerializer.Serialize(actual));
    }

    [Test]
    public void get_travel_detail_by_id_should_success()
    {
        var acutal = _myTravelController.Get(1);
        var expected = new TravelDetailResponse()
        {
            TravelDetail = new List<TravelDetail>
            {
                new TravelDetail
                {
                    Id = 1,
                    Attraction = "淡水老街",
                    Address = "淡水",
                    StartDate = new DateTime(2021, 9, 27),
                    EndDate = new DateTime(2021, 9, 29),
                    Context = "水老街分成外側靠淡水河岸的部分(金色水岸步道)與內側的老街，四處可見此區著名的古早味現烤蛋糕、烤魷魚、阿婆鐵蛋、魚酥、巨無霸冰淇淋還有淡水魚丸等等，都是來到此地必吃不可的美食。 從淡水捷運站走出來右轉，中正路及延伸的重建街、清水街一帶，就是鼎鼎大名的淡水老街。 ... 傍晚時，在金色水岸步道還可欣賞夕陽落入海面的美景。",
                    PictureName = "Wuling.jpeg"
                }
            }
        };

        Assert.AreEqual(JsonSerializer.Serialize(expected), JsonSerializer.Serialize(acutal));
    }
}