using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LHStextController : MonoBehaviour
{

    LevelCounter lc;
    public Text txt;

    string lvl1txt =
        "file { '/data/log.txt':\n"+
        "\tensure => present,\n"+
    	"\towner => 'root'\n"+
        "}\n\n\n"+
        "user { 'guest':\n"+
    	"\tensure => present,\n"+
    	"\tuid => 3\n"+
        "}\n\n"
        ;
    string lvl2txt =
        "group { 'sys':\n"+
        "\tensure => present,\n"+
        "\tgid => 0\n"+
        "}\n\n\n"+
        "user { 'root':\n"+
        "\tensure => present,\n"+
        "\tgroups => 'sys',\n"+
        "\tgid => 0,\n"+
        "\tuid => 0,\n"+
        "\tshell => '/bin/bash',\n" +
        "\thome => '/root'\n"+
        "}\n\n\n"+
        "user { 'guest':\n"+
        "\tensure => absent\n"+
        "}\n\n\n"+
        "file { '/data':\n"+
        "\tensure => directory\n"+
        "}\n\n\n"+
        "file { '/data/users.txt':\n"+
        "\tensure => present,\n"+
        "\tcontent => 'root, alice'\n"+
        "\towner => 'root',\n"+
        "\tgroup => 'root',\n"+
        "\tmode => '0600'\n"+
        "}\n\n\n"
        ;
    string lvl3txt =
        
        "class root {\n" +
        "\t$dir = '/home'\n" +
        "\tuser { 'root':\n" +
        "\t\tensure => present,\n" +
        "\t\tgroups => 'sys',\n" +
        "\t\tgid => 0,\n" +
        "\t\tshell => '/bin/bash',\n" +
        "\t\thome => \"$dir/root\"\n" +
        "\t}\n\n" +
        "\tfile { $dir:\n" +
        "\t\tensure => directory\n" +
        "\t}\n" +
        "}\n\n" +
        "include root\n\n"
        ;
    string lvl4txt =
        "class openssh {\n" +
        "\tpackage { 'openssh-server':\n" +
        "\t\tensure => latest\n" +
        "\t}\n\n" +
        "\tservice { 'sshd':\n" +
        "\t\tensure => running,\n" +
        "\t\tenable => true\n" +
        "\t}\n\n" +
        "\tfile { '/etc/ssh/sshd_config':\n" +
        "\t\tmode => '0600',\n" +
        "\t\towner => 'root'\n" +
        "\t}\n\n" +
        "\texec { 'mkdir_backup':\n" +
        "\t\tcwd => 'etc/ssh/sshd_config',\n" +
        "\t\tcommand => 'mkdir backup'\n" +
        "\t}\n" +
        "}\n\n" +
        "include openssh\n\n"
        ;
    string lvl5txt=
        "class users (\n" +
        "\t$user  =  'default',\n" +
        "\t$dir  =  'default'\n" +
        "\t)\n" +
        "{\n" +
        "\tuser { $user:\n" +
        "\t\tensure  =>  present,\n" +
        "\t\thome  =>  \"$dir/$user\"\n" +
        "\t}\n" +
        "\t\n" +
        "\tfile { \"$dir/$user\":\n" +
        "\t\tensure  =>  directory,\n" +
        "\t\towner  =>  $user\n" +
        "\t\tmode  =>  '0644'\n" +
        "\t}\n" +
        "}\n\n" +
        "class { 'users':\n" +
        "\t$user  =>  'alice',\n" +
        "\t$dir  =>  '/users'\n" +
        "}\n\n\n";


    string lvl6txt =
        "class apache ( \n" +
        "\t$version  = latest\n" +
        "\t)\n" +
        "{\n" +
        "\texec { 'apt-get-update':\n" +
        "\t\tcwd  =>  '/usr/bin',\n" +
        "\t\tuser  =>  'root',\n" +
        "\t\tcommand  =>  'apt-get update'\n" +
        "\t}\n" +
        "\t\n" +
        "\tpackage { 'apache2':\n" +
        "\t\tensure  =>  $version,\n" +
        "\t\trequire  =>  Exec['apt-get-update']\n" +
        "\t}\n" +
        "\t\n" +
        "\tservice { 'apache2':\n" +
        "\t\tensure  =>  running,\n" +
        "\t\tenable  =>  true,\n" +
        "\t\trequire  =>  Package['apache2']\n" +
        "\t}\n" +
        "}\n\n" +
        "class {'apache':\n" +
        "\t$version  =>  '2.4'\n" +
        "}\n\n";



    void Start()
    {
        lc = GameObject.Find("TopCanvas").GetComponent<LevelCounter>();
        int counter = lc.getLevel();

        if (counter == 1)
        {
            txt.text = lvl1txt;
        }
        else if (counter == 2)
        {
            txt.text = lvl2txt;
        }
        else if (counter == 3)
        {
            txt.text = lvl3txt;
        }
        else if (counter == 4)
        {
            txt.text = lvl4txt;
        }
        else if (counter == 5)
        {
            txt.text = lvl5txt;
        }
        else if (counter == 6)
        {
            txt.text = lvl6txt;
        }
    }
}
