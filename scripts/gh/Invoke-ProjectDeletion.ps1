$owner = "lfarci";
$repository = "test-temp";
$labelsJsonPath = "C:\Users\logan\Development\Repos\azure\.github\data\labels.json";
$milestonesJsonPath = "C:\Users\logan\Development\Repos\azure\.github\data\milestones.json";

$labelsJsonContent = Get-Content -Raw -Path $labelsJsonPath | ConvertFrom-Json
$milestonesJsonContent = Get-Content -Raw -Path $milestonesJsonPath | ConvertFrom-Json

foreach ($label in $jsonContent.labels) {
    $deleteLabelCommand = "gh label delete --repo '$owner/$repository' '$($label.name)' --yes";
    Invoke-Expression $deleteLabelCommand;
}

foreach ($milestone in $milestonesJsonContent.milestones) {
    $deleteMilestoneCommand = "gh milestone delete $repository --title '$($milestone.title)'";
    Invoke-Expression $deleteMilestoneCommand;
}