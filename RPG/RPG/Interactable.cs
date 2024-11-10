using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class Interactable
    {
        /// <summary>
        /// all of the below values match up to their locations in the tilemap. 
        /// </summary>
        public int pumpkin = 301;
        public int[] redDoors = new int[] { 40, 41, 42, 43, 44, 45 };
        public int openRedDoor = 46;
        public int[] brownDoors = new int[] { 106, 107, 108, 109, 110, 111 };
        public int openBrownDoor = 112;
        public int[] signs = new int[] { 116, 149, 251, 284 };
        public int well = 1478;
        public int trashcanOrPotInTheRestaruntThing = 52;
        public int[] tombstones = new int[] { 181, 182, 183, 214, 215, 216 };
        public int whiteTent = 645;
        public int[] allInteractables = new int[] { 645, 181, 182, 183, 214, 215, 216, 52, 1478, 40, 41, 42, 43, 44, 45, 106, 107, 108, 109, 110, 111, 116, 149, 251, 284 };
        public bool CanInteract(int i)
        {
            if(Array.Exists(allInteractables, element => element == i)){
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
