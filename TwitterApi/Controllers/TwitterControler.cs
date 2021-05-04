using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tweetinvi;
using TwitterApi.Model;

namespace TwitterApi.Controllers

{
    [ApiController]
    [Route("api/tweet")]
    public class TwitterController : ControllerBase
    {
        [HttpPost]
        [Route("twitter")]
        public async Task<IActionResult> TweetPost([FromBody] Twt tweets)
        {
            string appKey = "1CUVgROst0lVt5KcBwLAKIg5D";
            string appSecret = "810xzO2iN7m6ufBlbbYwqe4ipfVOvXJrMqQM1z79xnBXdFXyya";
            string accessToken = "1169181938973732869-BGTDv8M9m0cchkSgDPV5SWWCQpjfqh";
            string accessTokenSecret = "y6JPtdlElHrJBGLGXOPlflZbf1OhvpPeQs00ID897STFy";
            try
            {

                var userClient = new TwitterClient(appKey, appSecret, accessToken, accessTokenSecret);
                var publishedTweet = await userClient.Tweets.PublishTweetAsync(tweets.message);
                return Ok("Tweet Posted");


            }
            catch (Exception e)
            {
                return Unauthorized(e.Message + " " + e.StackTrace);
            }



        }

    }
}