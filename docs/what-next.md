# What's next? (backend)

There are of course many things which could be improved or added. Here are some of them.

1. **More unit tests** - in order to have better unit test coverage there could be also unit tests for classes without any of them. 
2. **Some end-to-end tests** - It's always good to have some end to end tests for testing whole request pipeline. From source to destination. 
3. **More logs** - It's good practice to log more information and warning logs not only exceptions. So solution for that is to inject logger instance into main pipeline classes and log more information about pipeline process.
4. **Controllers versioning** - there could be versioning configured for future easy extension of API. So current controller could be marked as V1.
5. **CI/CD pipeline** - There is no destination server for this project but would be nice to develop at least some continuous integration. Maybe some github actions?
6. **Vault storage** - For secrets in project it's good practice to use some vault storage like KeyVault in Azure.