using System;
using Xunit;
using RoomCalculator;

namespace RoomCalculator.Tests
{
    public class RoomCalculator_Tests
    {
        private readonly Room _room;

        public RoomCalculator_Tests(){
            _room = new Room{
                WidthInMetres = 10,
                LengthInMetres = 5,
                HeightInMetres = 2,
                NumberOfDoors = 0,
                NumberOfWindows = 0,
                DoorSize = (1.981 * 0.762),
                WindowSize = (1.050 * 0.915)
            };
        }
        
        [Fact]
        public void CheckFloorAreaGeneratesCorrectly()
        { // checks if the room generates the correct floor area for given values

            var result = _room.GetFloorArea() == 50;

            Assert.True(result, "For a 10 x 5 room, floor area should equal 50");

        }

        [Fact]
        public void CheckSurfaceAreaGeneratesCorrectly()
        { // checks if the room generates the correct surface area for given values

            var result = _room.GetTotalWallSurfaceArea() == 60;

            Assert.True(result, "For a 10 x 5 x 2 room, surface area should equal 60");
        }

        [Fact]
        public void CheckVolumeGeneratesCorrectly()
        { // checks if the room generates the correct volume for given values

            var result = _room.GetVolume() == 100;

            Assert.True(result, "For a 10 x 5 x 2 room, volume should equal 100");
        }
        
    }
}
