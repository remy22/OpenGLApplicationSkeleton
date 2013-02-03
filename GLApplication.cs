using System;

namespace OpenGLParticles
{
	public interface GLApplication
	{
		void Initialize();
		void Update(float delta_time);
		void Resize(uint height, uint width);
		void Render();
	}
}

