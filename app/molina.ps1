function Solve-ServerName {
    param(
        [string]$azureRegion,
        [string]$appName,
        [string]$component,
        [string]$farmRole,
        [string]$environment,
        [string]$operatingSystem,
        [string]$serverCount
    )

    $serverName = New-Object System.Text.StringBuilder

    switch ($azureRegion) {
        "SC Region" { $serverName.Append("DC10 ") }
        "NC Region" { $serverName.Append("DC20 ") }
        "Azure Stack" { $serverName.Append("DC30 ") }
        default { throw "Invalid azure region" }
    }

    if ($appName.Length -ge 3) {
        $serverName.Append($appName.Substring(0, 3) + " ")
    } else {
        throw "Invalid app name"
    }

    if ($component.Length -gt 3) {
        $serverName.Append($component.Substring(0, 3) + " ")
    } elseif ($component.Length -gt 1) {
        $serverName.Append($component + " ")
    } else {
        throw "Invalid component"
    }

    switch ($farmRole) {
        "Web" { $serverName.Append("W ") }
        "App" { $serverName.Append("A ") }
        "Database" { $serverName.Append("D ") }
        "App/Web" { $serverName.Append("A ") }
        default { throw "Invalid farm role" }
    }

    switch ($environment) {
        "Development" { $serverName.Append("D ") }
        "QA" { $serverName.Append("Q ") }
        "UAT" { $serverName.Append("U ") }
        "Training" { $serverName.Append("T ") }
        "Stage" { $serverName.Append("S ") }
        "Production" { $serverName.Append("P ") }
        "DR" { $serverName.Append("P ") }
        default { throw "Invalid environment" }
    }

    switch ($operatingSystem) {
        "Windows" { $serverName.Append("W ") }
        "Linux" { $serverName.Append("L ") }
        default { throw "Invalid operating system" }
    }

    if ([int]$serverCount -gt 0 -and [int]$serverCount -lt 100) {
        for ($i = 1; $i -le [int]$serverCount; $i++) {
            $serverNumber = "{0:D2}" -f $i
            Write-Host ($serverName.ToString() + " " + $serverNumber)
        }
    } else {
        throw "Invalid Server Count"
    }
}

try {
    # Prompt the user for input
    Write-Host "Enter Azure Region:"
    $azureRegion = Read-Host

    Write-Host "Enter App Name:"
    $appName = Read-Host

    Write-Host "Enter Component:"
    $component = Read-Host

    Write-Host "Enter Farm Role:"
    $farmRole = Read-Host

    Write-Host "Enter Environment:"
    $environment = Read-Host

    Write-Host "Enter Operating System:"
    $operatingSystem = Read-Host

    Write-Host "Enter Server Count:"
    $serverCount = Read-Host

    # Call the Solve-ServerName function with user-provided inputs
    Solve-ServerName -azureRegion $azureRegion -appName $appName -component $component -farmRole $farmRole -environment $environment -operatingSystem $operatingSystem -serverCount $serverCount
} catch {
    Write-Host "Exception: $_"
}
