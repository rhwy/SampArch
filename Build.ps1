clear

$configuration = "Release" 
$specialRevision = "0"
$currentPath =  $myinvocation.mycommand.path | split-path -parent

&"$env:windir\Microsoft.NET\Framework\v4.0.30319\msbuild" $currentPath\Build\Build.proj /p:Configuration="$configuration" /p:Revision="$specialRevision"