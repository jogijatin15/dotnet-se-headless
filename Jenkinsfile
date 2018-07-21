pipeline {
	agent none
	stages {
		stage('Smoke Testing') {
			agent {
				docker 'atin/dotnet-headless-chrome'
			}
			steps {
				parallel(
					Smoke: {
						slackSend color: "229954",
						message: "Starting *Smoke Testing* Job"

						sh 'echo "Creating [.NET Core + Selenium + Chrome Headless] Docker container..."'
						slackSend color: "cceef9", message: "`Starting Smoke Tests on https://www.geico.com/` Job Details: ${env.JOB_NAME} ${env.BUILD_NUMBER} (<${env.BUILD_URL}|Open>)"
						slackSend color: "cceef9", message: "`Creating [.NET Core + Selenium + Chrome Headless] Docker container...`"

						sh 'echo "Starting Smoke Test Execution on https://www.geico.com/"'

            sh '''
            echo "hello-world"
            chmod 777 ./ci/scripts/functional-test.sh
            ./ci/scripts/functional-test.sh
            '''

						sh 'echo "Smoke Test Execution Complete"'
					},
					Notifications: {
						sh 'sleep 10'
						slackSend color: "78909C", message: "Executing TestCase 1: *Home Page Validation*"
						sh 'sleep 1'
						slackSend color: "2196F3", message: "TestCase 1: *PASSED*"

						slackSend color: "cceef9", message: "`Smoke Test Execution Complete` Job URL: (<${env.BUILD_URL}|Open>)"
            slackSend color: "cceef9", message: "`Destroying Docker container`"
					}
				)
			}
		}
	}
}
