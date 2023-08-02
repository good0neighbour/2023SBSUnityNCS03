//main light(장면에 배치된 direction light를 얻는다)의 빝벡터를 얻어오는 함수
void CustomLightDir_float(out float3 tDir)
{
#ifdef SHADERGRAPH_PREVIEW
	tDir = float3(1, 1, 1);
#else
	Light tLight = GetMainLight();
	tDir = tLight.direction;
#endif
}