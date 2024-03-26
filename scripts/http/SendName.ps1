$headers = @{
    'Content-Type' = 'application/json'
    'x-functions-key' = ''
}

$body = @{
    'name' = 'Logan'
} | ConvertTo-Json

$response = Invoke-WebRequest -Uri 'https://lfarci-functions.azurewebsites.net/api/HttpTrigger1' -Method POST -Body $body -Headers $headers

Write-Host $response | ConvertTo-Json