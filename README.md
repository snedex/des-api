# des-api string diff endpoint
 
API endpoint for storing base64 encoded strings and performing diffs on them.

# DB setup

This project uses EF core with migrations. To initialise the database run the following:

Visual Studio: In the Powershell Package Manager:

``` 
Update-Database 
```

VS Code: In the terminal:

``` 
 dotnet ef database update
```

# Use

The API presents 3 endpoints for performing the diff, this is a three stage operation. 

1. Supply the Left or Right value to the appropriate endpoint
2. Supply the Left or Right value not given in step 1 to the appropriate endpoint
3. Call the diff endpoint for the comparison

The client will supply the diff id as part of the submission of data and is expected to ensure it remains the same across the three invocations.


# Endpoints

## Register Left Data

Endpoint URL: http://localhost:port/v1/diff/{id}/left

HTTP Method: PUT

Example for diff 1337:
```
curl -X 'PUT' 'https://localhost:port/v1/diff/1337/left' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "data": "AAAAA=="
}'
```

## Register Right Data

Endpoint URL: http://localhost:port/v1/diff/{id}/right

HTTP Method: PUT

Example for diff 1337:
```
curl -X 'PUT' 'https://localhost:port/v1/diff/1337/right' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "data": "AQABAQ=="
}'
```

## Perform Diff

Endpoint URL: http://localhost:port/v1/diff/{id}

HTTP Method: GET

```
curl -X 'GET' 'https://localhost:port/v1/diff/1337'
```

# Response

The Diff call returns a simple JSON object with an array of discpreancies if any were found. Data structure is as follows:

```
{
  "diffResultType": "string",
  "diffs": [
    {
      "offset": 0,
      "length": 0
    }
  ]
}
```

The diffResultType has three return values:

| diffResultType         | Description |
|--------------|:------------------|
| Equals | The strings supplied are equal  |
| ContentDoNotMatch | The strings contain one or more differences |
| SizeDoNotMatch | The strings differ in length |


Offset in the diffs array is zero based from the start of the string.

The API will return a not found if the Left or Right data is missing.

# Swagger

Swagger is located for testing purposes here: http://localhost:port/swagger/index.html