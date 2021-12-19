using System;
using System.Collections.Generic;
using System.Text;

namespace Htx_Labs_Full_Stack_Dev_Test
{
    public interface IGame_Particle_System
    {
        public Game_Particle_System AddParticleToSystem();
        public ParticleGroup ModifyIntensity(ParticleGroup particleGroup, double modifier);
        public ParticleGroup AttachParticleSystemToTarget(ParticleGroup particleGroup, GameObject target);
        // Others

    }
}
