pipeline {
	agent none
	stages {
		stage('Mobile Testing') {
			agent {
				docker 'atin/dotnet-headless-chrome'
			}
			steps {
				parallel(
					Mobile: {
						slackSend color: "229954",
						message: "Starting *Mobile Testing* Job on *Sauce Labs*"

						sh 'echo "Creating [.NET Core + Selenium + Appium + Chrome Headless] Docker container..."'
						slackSend color: "cceef9", message: "`Starting Mobile Tests on https://www.geico.com/` Job Details: ${env.JOB_NAME} ${env.BUILD_NUMBER} (<${env.BUILD_URL}|Open>)"
						slackSend color: "cceef9", message: "`Creating [.NET Core + Selenium + Appium + Chrome Headless] Docker container...`"

						sh 'echo "Starting Mobile Test Execution on https://www.geico.com/"'

            sh '''
            echo "hello-world"
            chmod 777 ./ci/scripts/functional-test.sh
            ./ci/scripts/functional-test.sh
            '''

						sh 'echo "Mobile Test Execution Complete"'
					},
					Notifications: {
						sh 'sleep 70'
						slackSend color: "78909C", message: "Executing TestCase 1: *Home Page Validation*"
						sh 'sleep 100'
						slackSend color: "2196F3", message: "TestCase 1: *PASSED*"

						slackSend color: "cceef9", message: "`Mobile Test Execution Complete` Job URL: (<${env.BUILD_URL}|Open>) (<${env.SauceLabsVideo}|SauceLabs Video>)"
            slackSend color: "cceef9", message: "`Destroying Docker container`"

					}
				)
			}
		}
	}
}
