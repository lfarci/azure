function Read-RequiredString {
    param (
        [Parameter(Mandatory=$true)]
        [string]$Prompt
    )

    do {
        $Text = Read-Host -Prompt $Prompt
        if ([string]::IsNullOrEmpty($Text)) {
            Write-Host "$Prompt is required and cannot be empty. Please try again."
        }
    } while ([string]::IsNullOrEmpty($Text))

    return $Text
}

$Owner = Read-RequiredString -Prompt "Owner"
$Repository = Read-RequiredString -Prompt "Repository"

$Env:Owner = $Owner
$Env:Repository = $Repository