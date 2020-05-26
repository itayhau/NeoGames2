Hi,

the problem with the API is in the continue functionallity.

Since a continue request should have some identifier to continue from its last point
i added to the GetFromDate [API] method ,in the result, a position (index) which will be used
for all sequential requests (as part of the return JSON result)

Later on in each Continue [API] request, this position (index) should be sent return the sequential requested data

In the Continue [API] method i thought the startdate is not needed since we already remember the last position
therefor i only request the position (index) and the bulk size
if there is a need for  specific date, then the GetFromDate [API] method should be invoked

Thanks,
Itay.

