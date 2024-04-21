$owner = "lfarci";
$repository = "test-temp";
$labelsJsonPath = "C:\Users\logan\Development\Repos\azure\.github\data\labels.json";
$milestonesJsonPath = "C:\Users\logan\Development\Repos\azure\.github\data\milestones.json";

$labelsJsonContent = Get-Content -Raw -Path $labelsJsonPath | ConvertFrom-Json
$milestonesJsonContent = Get-Content -Raw -Path $milestonesJsonPath | ConvertFrom-Json

foreach ($label in $labelsJsonContent.labels) {
    $createLabelCommand = "gh api repos/$owner/$repository/labels -X POST -F name='$($label.name)' -F color='$($label.color)' -F description='$($label.description)'";
    Invoke-Expression $createLabelCommand;
}

foreach ($milestone in $milestonesJsonContent.milestones) {
    $createMilestoneCommand = "gh milestone create $repository --title '$($milestone.title)' --description '$($milestone.description)'";
    Invoke-Expression $createMilestoneCommand;
}
