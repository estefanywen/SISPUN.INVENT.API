pipeline {

    agent any
    environment{
        HOST_IP = '10.200.8.103'
        HOST_SSH_USER =  credentials('host_ssh_user_8_103')
        HOST_SSH_PASSWORD = credentials('host_ssh_password_8_103')
        PORT = 16003
    }
    
    stages {

        stage('Docker Building') {
        agent any
        steps {
            sh 'docker image rm sispun_msa_inventario || true'
            sh 'rm docker_sispun_msa_inventario_latest.tar || true'
            sh 'docker build -t sispun_msa_inventario .'
            sh 'docker save -o  docker_sispun_msa_inventario_latest.tar sispun_msa_inventario'
            sh 'ls'
        }
        }

        stage('Docker Transfer to Remote Host'){
        agent any
        steps{
            script{
                def remote = [:]
                remote.name = env.HOST_IP
                remote.host = env.HOST_IP
                remote.user = env.HOST_SSH_USER
                remote.password = env.HOST_SSH_PASSWORD
                remote.allowAnyHosts = true

                remote.fileTransfer = "sftp"
                sshCommand remote: remote, command: "pwd"
                sshCommand remote: remote, command: "mkdir -p sispuninv_dockers_images"
                sshCommand remote: remote, command: "cd sispuninv_dockers_images && rm  docker_sispun_msa_inventario_latest.tar || true"
                sshCommand remote: remote, command: "docker stop  \$( docker ps -q --filter ancestor=sispun_msa_inventario) || true"
                sshCommand remote: remote, command: "docker image rm sispun_msa_inventario || true"
                remote.fileTransfer = "scp"
                sshPut remote: remote, from: 'docker_sispun_msa_inventario_latest.tar', into: "sispuninv_dockers_images"  
                remote.fileTransfer = "sftp"
                sshCommand remote: remote, command: "cd sispuninv_dockers_images && docker load < docker_sispun_msa_inventario_latest.tar && docker image ls"
            }  
        }
        }

        stage('Docker Cleaning') {
        agent any
        steps {
            script{
                def remote = [:]
                remote.name = env.HOST_IP
                remote.host = env.HOST_IP
                remote.user = env.HOST_SSH_USER
                remote.password = env.HOST_SSH_PASSWORD
                remote.allowAnyHosts = true
                            
                remote.fileTransfer = "sftp"
                sshCommand remote: remote, command: "docker stop  \$( docker ps -q --filter ancestor=sispun_msa_inventario) || true"
            }  
        }
        }  



        stage('Docker Run') {
        agent any
        steps {
            script{
                def remote = [:]
                remote.name = env.HOST_IP
                remote.host = env.HOST_IP
                remote.user = env.HOST_SSH_USER
                remote.password = env.HOST_SSH_PASSWORD
                remote.allowAnyHosts = true
                            
                remote.fileTransfer = "sftp"
                sshCommand remote: remote, command: "docker run --add-host testingsiagie-externo-consultas-api.minedu.gob.pe:10.1.1.155 --add-host testingapipadron.minedu.gob.pe:10.200.4.92 -d -it --rm -p ${PORT}:80 sispun_msa_inventario"
            }  
        }
        }
    }
    
}


