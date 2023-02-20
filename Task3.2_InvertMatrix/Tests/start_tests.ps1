$scriptPath = Split-Path -Parent $global:MyInvocation.MyCommand.Definition;
$files = Get-ChildItem $($scriptPath + "\*") -Include *.input.txt;


$exeFiles = Get-ChildItem $($scriptPath + "\*") -Include *.exe;

if ( $exeFiles.Length -eq 0 ) {
    Write-Output "There is no exe files. Please add"
    exit 1;
}

$isAllSucced = $true;
foreach ($file in $files) {
    $nameArgs = $file.Name -split "\.";

    $testName = $nameArgs[0];
    if ( $nameArgs.Length -eq 4 ) {
        $testName = $($nameArgs[0] + "." + $nameArgs[1])
    }

    $reqExitCode = 0;
    if ( $nameArgs.Length -eq 4 ) {
        if ( $nameArgs[1] -eq "error" ) {
            $reqExitCode = 1;
        }
    }

    $inputFilePath = $scriptPath + "\" + $($testName + ".input.txt");
    $inputFileContent = (Get-Content $inputFilePath -Raw).Trim();

    $outputFilePath = $scriptPath + "\" + $($testName + ".output.txt");
    $outputFileContent = (Get-Content $outputFilePath -Raw).Trim();

    $pinfo = New-Object System.Diagnostics.ProcessStartInfo
    $pinfo.FileName =  $scriptPath + "\" + $exeFiles[0].Name
    $pinfo.Arguments = "$($inputFilePath)"
    $pinfo.RedirectStandardError = $true
    $pinfo.RedirectStandardOutput = $true
    $pinfo.UseShellExecute = $false

    $p = New-Object System.Diagnostics.Process
    $p.StartInfo = $pinfo
    $p.Start() | Out-Null
    $p.WaitForExit()

    $stdout = $p.StandardOutput.ReadToEnd().Trim()
    $stderr = $p.StandardError.ReadToEnd().Trim()

    if ( $outputFileContent.Trim() -eq $stdout -and $reqExitCode -eq $p.ExitCode ) {
        Write-Output "+ Test [$($file.Name)] succed."
    }
    else
    {
        Write-Output "- Test [$($file.Name)] failed."
        $isAllSucced = $false;
    }
    Write-Output "  > Program exit code: $($p.ExitCode)"
    Write-Output "  > Program output: $($stdout)"
}

if ( $isAllSucced ) {
    Write-Output ""
    Write-Output "All tests succed"
    exit 0;
}

exit 1;