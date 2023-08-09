void CustomLightDir_float(out float3 tDir)
{
#ifdef SHADERGRAPH_PREVIEW
	tDir = float3(1, 1, 1);
#else
	Light tLight = GetMainLight();
	tDir = tLight.direction;
#endif
}