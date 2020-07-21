using System;

namespace CodeCamp2020.Shared.Models
{
    public class Moves
    {
        private MoveStat _tackle;
        public MoveStat Tackle
        {
            get
            {
                if (_tackle == null)
                    _tackle = new MoveStat();

                return _tackle;
            }

            set { _tackle = value; }
        }

        private MoveStat _growl;
        public MoveStat Growl
        {
            get
            {
                if (_growl == null)
                    _growl = new MoveStat();

                return _growl;
            }

            set { _growl = value; }
        }

        private MoveStat _leechSeed;
        public MoveStat LeechSeed
        {
            get
            {
                if (_leechSeed == null)
                    _leechSeed = new MoveStat();

                return _leechSeed;
            }

            set { _leechSeed = value; }
        }

        private MoveStat _vineWhip;
        public MoveStat VineWhip
        {
            get
            {
                if (_vineWhip == null)
                    _vineWhip = new MoveStat();

                return _vineWhip;
            }

            set { _vineWhip = value; }
        }

        private MoveStat _poisonPowder;
        public MoveStat PoisonPowder
        {
            get
            {
                if (_poisonPowder == null)
                    _poisonPowder = new MoveStat();

                return _poisonPowder;
            }

            set { _poisonPowder = value; }
        }

        private MoveStat _sleepPowder;
        public MoveStat SleepPowder
        {
            get
            {
                if (_sleepPowder == null)
                    _sleepPowder = new MoveStat();

                return _sleepPowder;
            }

            set { _sleepPowder = value; }
        }

        private MoveStat _takeDown;
        public MoveStat TakeDown
        {
            get
            {
                if (_takeDown == null)
                    _takeDown = new MoveStat();

                return _takeDown;
            }

            set { _takeDown = value; }
        }

        private MoveStat _razorLeaf;
        public MoveStat RazorLeaf
        {
            get
            {
                if (_razorLeaf == null)
                    _razorLeaf = new MoveStat();

                return _razorLeaf;
            }

            set { _razorLeaf = value; }
        }

        private MoveStat _sweetScent;
        public MoveStat SweetScent
        {
            get
            {
                if (_sweetScent == null)
                    _sweetScent = new MoveStat();

                return _sweetScent;
            }

            set { _sweetScent = value; }
        }

        private MoveStat _growth;
        public MoveStat Growth
        {
            get
            {
                if (_growth == null)
                    _growth = new MoveStat();

                return _growth;
            }

            set { _growth = value; }
        }

        private MoveStat _doubleEdge;
        public MoveStat DoubleEdge
        {
            get
            {
                if (_doubleEdge == null)
                    _doubleEdge = new MoveStat();

                return _doubleEdge;
            }

            set { _doubleEdge = value; }
        }

        private MoveStat _worrySeed;
        public MoveStat WorrySeed
        {
            get
            {
                if (_worrySeed == null)
                    _worrySeed = new MoveStat();

                return _worrySeed;
            }

            set { _worrySeed = value; }
        }

        private MoveStat _synthesis;
        public MoveStat Synthesis
        {
            get
            {
                if (_synthesis == null)
                    _synthesis = new MoveStat();

                return _synthesis;
            }

            set { _synthesis = value; }
        }

        private MoveStat _solarBeam;
        public MoveStat SolarBeam
        {
            get
            {
                if (_solarBeam == null)
                    _solarBeam = new MoveStat();

                return _solarBeam;
            }

            set { _solarBeam = value; }
        }
    }
}
