# Bootstorm-Stopwatch
Simple application created to time the boot time of a vSphere environment of VMs located on two seperate datastores

###Overview:
This tool was written to apply a reset command to a list of operational VMs within a clusters datastore and then track how long it takes all VMs to have their VMtools reporting as ‘running’. The reasoning behind this was to be able to show performance differences between two separate LUNs such as one that has FAST Cache enabled and one that doesn’t.
The demo that was the initial focus involved the following setup:
- Cluster of two nodes
  - Cisco UCS B250M2 X5680, 192GB RAM
  - ESXi 5.0
  - DRS disabled
  - VNX5500
  - 4 x 100Gb EFDs assigned to FAST Cache
  - RAID Group with 6+1 RAID5 NL-SAS drives
  - Two block LUNS presented from RAID Group to cluster
    - Lun1 SP Cache disabled, FAST enabled
    - Lun2 SP Cache disabled, FAST disabled
- Guest Environment
  - Two pools setup so that each LUN was provisioned with 50 linked clones from the same base image in different pools ensuring identical guest setup
  - Each pool assigned to separate Resource Pools for easy selection of VM lists when showing status
  - Each resource pool guest list shifted to their own host  ensuring that the hosts did not provide any advantage or disadvantage to either pool
  - Windows 7 64 bit , Office 2010, etc

By setting up in this way we were able to demonstrate prior to the commencement of the demo that the only difference in the whole setup between the two instances was the enablement of FAST cache without any smoke and mirrors used to tilt the result in our favour.
When it is kicked off the tool logic is

- The tool will send a hard reset to each guest that had reported its tools as being in a running state
- Once all guests have been reset it will then test to see if the tools is running. 
- If tools are running it then looks at the recent tasks listed against the guest to ensure that the last task status is ‘success’
    - This step was required as the non FAST LUN guests tend to take ages to even complete the reset command so the tools were still running by the time the validation step was commenced

##Findings:
When running the tests concurrently (excluding the mouse pointer lag clicking from one to the other) we were seeing the FAST Cache LUN completing somewhere around 1:40, with the non FAST Cache enabled LUN taking around 20 minutes. With SP Cache enabled on both the difference was about 50 seconds between them so not as dramatic but still a difference. The SP Cache enabled test results though were not as consistent.

Requirements:

•	VMware vCenter 5.x
•	VMware PowerCli  libraries
•	Microsoft .Net Framework 4

Instructions:

1.	Run the executable and connect to the target virtual center
2.	Select target cluster and LUN and the select the ‘Go For it’ button
Warning
Windows hates to many resets when it has not finished loading from the last one and did experience some guest corruptions as a result. The test will only be run against guests that have the tools already running to try and protect against this.
Improvements:

1.	Looking at threading the app it so that more reset commands can be executed concurrently for a higher guest count demo. Currently it executes synchronously.
2.	Could shift the test for completion to the tools reporting an IP address instead of just running, issue with this though is the test takes longer to run 




