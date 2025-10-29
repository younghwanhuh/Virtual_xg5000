# Virtual_xg5000

## WPF 애플리케이션

- 솔루션 파일: `Virtual_xg5000.sln`
- 기본 프로젝트: `Virtual_xg5000.App`
- 대상 프레임워크: `net9.0-windows`

### 구현된 기능

- WPF 기반 래더 편집기 UI
  - 도구 상자에서 노멀 오픈/노멀 클로즈 접점과 코일을 선택해 런에 추가
  - 각 요소의 심볼 표시 및 주소(Label) 즉시 수정
  - 런 추가/요소 삭제 지원

### 빌드 및 실행

```powershell
dotnet build
dotnet run --project .\Virtual_xg5000.App
```
