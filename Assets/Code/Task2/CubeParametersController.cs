namespace Code.Task2
{
    public class CubeParametersController
    {
        private readonly CubeSpawner _spawner;
        private readonly CubeMover _mover;
        private readonly CubeDestroyer _destroyer;
        
        public CubeParametersController(
            CubeSpawner spawner, 
            CubeMover mover, 
            CubeDestroyer destroyer)
        {
            _spawner = spawner;
            _mover = mover;
            _destroyer = destroyer;
        }

        public bool HandleNewSpeedInput(string value)
        {
            var isValid = float.TryParse(value, out var floatValue);

            if (isValid)
                _mover.ChangeMoveSpeed(floatValue);

            return isValid;
        }
        
        public bool HandleNewDistanceInput(string value)
        {
            var isValid = float.TryParse(value, out var floatValue);

            if (isValid)
                _destroyer.ChangeDistanceToDestroyValue(floatValue);
            
            return isValid;
        }
        
        public bool HandleNewRespawnDurationInput(string value)
        {
            var isValid = float.TryParse(value, out var floatValue);

            if (isValid)
                _spawner.ChangeRespawnDuration(floatValue);
            
            return isValid;
        }
    }
}