$headers = @{
    'Content-Type' = 'application/json'
    'x-functions-key' = 'Q4uA_GiJf9RtbYpNKmgo271guktVncY2di-UyyqRvSavAzFuBoRneg=='
}

$body = @{
    'name' = 'Logan'
} | ConvertTo-Json

$response = Invoke-WebRequest -Uri 'https://lfarci-functions.azurewebsites.net/api/HttpTrigger1' -Method POST -Body $body -Headers $headers

Write-Host $response | ConvertTo-Json