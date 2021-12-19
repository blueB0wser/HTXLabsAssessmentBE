using System;
using System.Collections.Generic;
using System.Text;

namespace Htx_Labs_Full_Stack_Dev_Test
{
    public class Game_Particle_System : IGame_Particle_System
    {
        public ParticleGroup[] AppliedParticles { get; set; }

        public Game_Particle_System AddParticleToSystem()
        {
            throw new NotImplementedException();
        }

        public ParticleGroup AttachParticleSystemToTarget(ParticleGroup particleGroup, GameObject target)
        {
            throw new NotImplementedException();
        }

        public ParticleGroup ModifyIntensity(ParticleGroup particleGroup, double modifier)
        {
            throw new NotImplementedException();
        }
    }
    public class ParticleGroup
    {
        public string Type { get; set; }
        public bool IsActive { get; set; }
        public int Intensity { get; set; }
        ObjectDetails ObjectDetails { get; set; }
    }

    public class GameObject
    {
        ParticleGroup AttachedParticleGroup { get; set; }
        ObjectDetails ObjectDetails { get; set; }
    }

    public class ObjectDetails
    {
        public double Location { get; set; }
        public double Scale { get; set; }
        public double Rotation { get; set; }
    }
}
