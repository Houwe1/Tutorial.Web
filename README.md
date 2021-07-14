# Tutorial.Web

Web Develop Tutorial.

## 一台电脑如何配置多个 Git 用户信息

1.取消原来的全局设置

```
git config --global --unset user.name
git config --global --unset user.email
```

2.设置每个项目 repository 的 email

```
git config  user.email "user@xxx.com"
git config  user.name "username"
```

3.生成 SSH Keys

1. 设置 SSH Keys

```
ssh-keygen -t rsa -C "user@xxx.com"
```

平时我们都是直接回车，默认生成 id_rsa 和 id_rsa.pub。这里特别需要注意，出现提示输入文件名的时候(Enter file in which to save the key (~/.ssh/id_rsa): id_rsa_new)要输入与默认配置不一样的文件名，比如：我这里填的是 id_rsa_new.

注：windows 用户和 mac 用户的区别就是，mac 中 .ssh 文件夹在根目录下，所以表示成 ~/.ssh/ ,而 windwos 用户是 C:\Users\Administrator\.ssh

2.  执行 ssh-agent 让 ssh 识别新的私钥，因为默认只读取 id_rsa，为了让 SSH 识别新的私钥，需将其添加到 SSH agent

```
ssh-add ~/.ssh/id_rsa_new
```

如果出现 Could not open a connection to your authentication agent 的错误，就试着用以下命令：

```
ssh-agent bash
ssh-add ~/.ssh/id_rsa_work
```

3.  **配置 ~/.ssh/config 文件**

```
# First User Config
Host xxx.com
HostName xxx.com
User xxx
IdentityFile C:\\Users\\xxx\\.ssh\\id_rsa

# Second User Config
Host github.com
HostName github.com
User yyy
IdentityFile C:\\Users\\xxx\\.ssh\\id_rsa_github
```

## 如何设置 GitHub 的代码权限
