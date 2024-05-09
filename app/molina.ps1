function Solve {
    param(
        [string]$azureRegion,
        [string]$appName,
        [string]$component,
        [string]$farmRole,
        [string]$environment,
        [string]$operatingSystem,
        [string]$seqNumber
    )

    $serverName = New-Object -TypeName System.Text.StringBuilder

    # Concatenate azure region
    switch ($azureRegion) {
        "SC Region" { $serverName.Append("DC10 ") }
        "NC Region" { $serverName.Append("DC20 ") }
        "Azure Stack" { $serverName.Append("DC30 ") }
        default { throw "Invalid azure region" }
    }

    # Concatenate app name
    if ($appName.Length -ge 3) {
        $serverName.Append($appName.Substring(0, 3) + " ")
    } else {
        throw "Invalid app name"
    }

    # Concatenate component
    if ($component.Length -gt 3) {
        $serverName.Append($component.Substring(0, 3) + " ")
    } elseif ($component.Length -gt 1) {
        $serverName.Append($component + " ")
    } else {
        throw "Invalid component"
    }

    # Concatenate farm role
    switch ($farmRole) {
        "Web" { $serverName.Append("W ") }
        "App" { $serverName.Append("A ") }
        "Database" { $serverName.Append("D ") }
        "App/Web" { $serverName.Append("A ") }
        default { throw "Invalid farm role" }
    }

    # Concatenate environment
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

    # Concatenate operating system
    switch ($operatingSystem) {
        "Windows" { $serverName.Append("W ") }
        "Linux" { $serverName.Append("L ") }
        default { throw "Invalid operating system" }
    }

    # Concatenate seq number
    $serverName.Append($seqNumber)


    Write-Host "Server name: $($serverName.ToString())"
}

# Test the function
try {
    Solve -azureRegion "SC Region" -appName "MyApp" -component "Component1" -farmRole "Web" -environment "Development" -operatingSystem "Windows" -seqNumber "12345"
} catch {
    Write-Host "Error: $_"
}
