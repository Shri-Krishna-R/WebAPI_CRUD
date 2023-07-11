using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendsController : ControllerBase
    {
        static List<string> myFriends = new List<string> () { "Vikram", "Ranjan", "Mano", "Vipul", "Rasheed","Marsh","Michael" };

        #region Get
        [HttpGet]
        [Route("/List")]
        public IActionResult GetAllFriends ()
        {
            return Ok(myFriends);
        }
        [HttpGet]
        [Route("/Index/{id}")]
        public IActionResult GetFriendByIndex (int id)
        {
            if (myFriends.Count < id)
            {
                return NotFound(string.Format($"Sorry friend not found with the id:" +id));
            }
            string friend = myFriends[id];
            return Ok(friend);
        }
        [HttpGet]
        [Route("/Character/{chars}")]
        public  IActionResult GetFriendByChar(string chars)
        {
            var friend = from f in myFriends where f.StartsWith(chars) select f;
            return Ok(friend);
        }
        [HttpGet]
        [Route("/Count")]
        public IActionResult GetCount() {
            return Ok(myFriends.Count);
        }
        #endregion

        #region Post
        [HttpPost]
        [Route("/add")]
        public IActionResult AddFriend (string name)
        {
            myFriends.Add(name);
            return Ok(name + " Is added to the list");
        }
        #endregion

        #region Delete
        [HttpDelete]
        [Route("/delete/{id}")]
        public IActionResult DeleteFriend (int id) {
            string name = myFriends[id];
            myFriends.RemoveAt(id);
            return Accepted(name + " has been removed from Friend List.");
        
        }
        [HttpDelete]
        [Route("/delete/ByName/{name}")]
        public IActionResult DeleteFriendByName(string name)
        {
            myFriends.Remove(name);
            return Accepted(name + " has been removed from Friend List.");

        }
        #endregion

        #region Put
        [HttpPut]
        [Route("/update/{id}/{name}")]
        public IActionResult UpdateFriend (int id, string name)
        {
            string oldname = myFriends[id];
            myFriends[id] = name;
            return Ok(name + " Has been updated from " +oldname);
        }
        #endregion

    }
}
