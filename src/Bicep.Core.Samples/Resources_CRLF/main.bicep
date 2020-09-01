resource test 'Microsoft.DataFactory/factories@2018-06-01' = {
  name: 'test'
  properties: {
    globalParameters: {
    
    }
    repoConfiguration: {
      accountName: 'steve'
      collaborationBranch: 'asd'
      repositoryName: 'arnold'
      rootFolder: '/'
    }
  } 
}

resource test2 'Microsoft.Web/certificates@2018-11-01' = {
  name: 'asdasfd'
  location: 'here'
  properties: {
    password: 'abcdefg'
  }
}

resource myVm 'Microsoft.Compute/virtualMachines@2020-06-01' = {
  name: 'jobby'
  location: 'West US'
  properties: {
    s: 'a'
  }
}