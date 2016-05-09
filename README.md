# EntityPlugin.RWSplitting

[![Build status](https://ci.appveyor.com/api/projects/status/cx0rqm3kr4jv5ra4/branch/master?svg=true)](https://ci.appveyor.com/project/yaozhenfa/entityplugin-rwsplitting/branch/master)   

EF读写分离插件

### 安装方式
```
Install-Package EntityPlugin.RWSplitting
```

## 使用方式
```
EFMasterSlaveConfig.Register(typeof(TestDbContext));
```
只需要在应用启动的时候利用以上代码即可初始化完成，另外还需要“ef.masterslave.config”配置文件：
```
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
	<configSections>
		<section name="ef.masterslave" type="EntityPlugin.RWSplitting.MasterSlaves.EFMasterSlaveSection, EntityPlugin.RWSplitting"
				 requirePermission="false" />
	</configSections>
	<ef.masterslave>
		<applyItem targetContext="EntityPlugin.RWSplitting.Test.TestDbContext, EntityPlugin.RWSplitting.Test"
                       autoSwitchSlaveOnMasterFauled="false" autoSwitchMasterOnSlavesFauled="true"
                       serverStateScanInterval="60" serverStateScanWithNonOffline="false"
                       slaveRandomization="true" >
			<master connectionString="[写数据库连接字符串]" />
			<slaves>
				<add connectionString="[读数据库连接字符串1]" order="0" />
			</slaves>
		</applyItem>
	</ef.masterslave>
</configuration>
```
