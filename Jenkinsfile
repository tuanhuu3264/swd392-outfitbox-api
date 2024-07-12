pipeline {

    agent any

    
    stages {

        stage('Packaging') {

            steps {
                
                sh 'docker build --pull --rm -f Dockerfile -t outfitbox-api:latest .'
                
            }
        }

        stage('Push to DockerHub') {

            steps {
                withDockerRegistry(credentialsId: 'dockerhub', url: 'https://index.docker.io/v1/') {
                    sh 'docker tag outfitbox-api:latest famsphase/outfitbox-api:latest'
                    sh 'docker push famsphase/outfitbox-api:latest'
                }
            }
        }

        stage('Deploy FE to DEV') {
            steps {
                echo 'Deploying and cleaning'
                sh 'docker container stop outfitbox-api || echo "this container does not exist" '
                sh 'echo y | docker system prune '
                sh 'docker container run -d --rm --name outfitbox-api -p 8080:80 -p 4433:443 famsphase/outfitbox-api '
            }
        }
        
 
    }
    post {
        always {
            cleanWs()
        }
    }
}