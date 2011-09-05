
EXTRA_DIST =  

# Warning: This is an automatically generated file, do not edit!

if ENABLE_DEBUG
ASSEMBLY_COMPILER_COMMAND = gmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize- -debug -langversion:ISO-2  "-define:DEBUG;TRACE" "-main:Pedal_Power_Interface_v2.Program"
ASSEMBLY = bin/Debug/Pedalog_Interface.exe
ASSEMBLY_MDB = $(ASSEMBLY).mdb
COMPILE_TARGET = winexe
PROJECT_REFERENCES = 
BUILD_DIR = bin/Debug/

PWPP_PEDALOG_DLL_CONFIG_SOURCE=Pwpp.Pedalog.dll.config
PEDALOG_INTERFACE_SOURCE=pedalog-interface
LIBPEDALOG_DLL_SOURCE=libpedalog.dll
ZEDGRAPH_DLL_SOURCE=../Assemblies/zedgraph_dll_v515/zedgraph_dll_v5.1.5/ZedGraph.dll
PWPP_PEDALOG_DLL_SOURCE=../Assemblies/libpedalog-mono/Pwpp.Pedalog.dll
PEDALOG_INTERFACE_EXE_MDB_SOURCE=bin/Debug/Pedalog_Interface.exe.mdb
PEDALOG_INTERFACE_EXE_MDB=$(BUILD_DIR)/Pedalog_Interface.exe.mdb

endif

if ENABLE_RELEASE
ASSEMBLY_COMPILER_COMMAND = gmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize+ -langversion:ISO-2  "-define:TRACE" "-main:Pedal_Power_Interface_v2.Program"
ASSEMBLY = bin/Release/Pedalog_Interface.exe
ASSEMBLY_MDB = 
COMPILE_TARGET = winexe
PROJECT_REFERENCES = 
BUILD_DIR = bin/Release/

PWPP_PEDALOG_DLL_CONFIG_SOURCE=Pwpp.Pedalog.dll.config
PEDALOG_INTERFACE_SOURCE=pedalog-interface
LIBPEDALOG_DLL_SOURCE=libpedalog.dll
ZEDGRAPH_DLL_SOURCE=../Assemblies/zedgraph_dll_v515/zedgraph_dll_v5.1.5/ZedGraph.dll
PWPP_PEDALOG_DLL_SOURCE=../Assemblies/libpedalog-mono/Pwpp.Pedalog.dll
PEDALOG_INTERFACE_EXE_MDB=

endif

AL=al2
SATELLITE_ASSEMBLY_NAME=$(notdir $(basename $(ASSEMBLY))).resources.dll

PROGRAMFILES = \
	$(PWPP_PEDALOG_DLL_CONFIG) \
	$(PEDALOG_INTERFACE) \
	$(LIBPEDALOG_DLL) \
	$(ZEDGRAPH_DLL) \
	$(PWPP_PEDALOG_DLL) \
	$(PEDALOG_INTERFACE_EXE_MDB)  

BINARIES = \
	$(PEDAL_POWER_INTERFACE_V4)  


RESGEN=resgen2
	
all: $(ASSEMBLY) $(PROGRAMFILES) $(BINARIES) 

FILES = \
	Form1.cs \
	Form1.Designer.cs \
	Program.cs \
	Properties/AssemblyInfo.cs \
	Properties/Resources.Designer.cs \
	Properties/Settings.Designer.cs 

DATA_FILES = 

RESOURCES = \
	Form1.resx,Pedal_Power_Interface_v2.Form1.resources \
	Properties/Resources.resx,Pedalog_Interface.Properties.Resources.resources 

EXTRAS = \
	Properties/app.manifest \
	Properties/Settings.settings \
	Pwpp.Pedalog.dll.config \
	pedalog-interface \
	Pedal_Power_Interface_v4_TemporaryKey.pfx \
	Resources \
	libpedalog.dll \
	pedal_power_interface_v4.in 

REFERENCES =  \
	System \
	System.Core \
	System.Drawing \
	System.Windows.Forms

DLL_REFERENCES =  \
	../Assemblies/zedgraph_dll_v515/zedgraph_dll_v5.1.5/ZedGraph.dll \
	../Assemblies/libpedalog-mono/Pwpp.Pedalog.dll

CLEANFILES = $(PROGRAMFILES) $(BINARIES) 

include $(top_srcdir)/Makefile.include

PWPP_PEDALOG_DLL_CONFIG = $(BUILD_DIR)/Pwpp.Pedalog.dll.config
PEDALOG_INTERFACE = $(BUILD_DIR)/pedalog-interface
LIBPEDALOG_DLL = $(BUILD_DIR)/libpedalog.dll
ZEDGRAPH_DLL = $(BUILD_DIR)/ZedGraph.dll
PWPP_PEDALOG_DLL = $(BUILD_DIR)/Pwpp.Pedalog.dll
PEDAL_POWER_INTERFACE_V4 = $(BUILD_DIR)/pedal_power_interface_v4

$(eval $(call emit-deploy-target,PWPP_PEDALOG_DLL_CONFIG))
$(eval $(call emit-deploy-target,PEDALOG_INTERFACE))
$(eval $(call emit-deploy-target,LIBPEDALOG_DLL))
$(eval $(call emit-deploy-target,ZEDGRAPH_DLL))
$(eval $(call emit-deploy-target,PWPP_PEDALOG_DLL))
$(eval $(call emit-deploy-wrapper,PEDAL_POWER_INTERFACE_V4,pedal_power_interface_v4,x))


$(eval $(call emit_resgen_targets))
$(build_xamlg_list): %.xaml.g.cs: %.xaml
	xamlg '$<'

$(ASSEMBLY_MDB): $(ASSEMBLY)

$(ASSEMBLY): $(build_sources) $(build_resources) $(build_datafiles) $(DLL_REFERENCES) $(PROJECT_REFERENCES) $(build_xamlg_list) $(build_satellite_assembly_list)
	mkdir -p $(shell dirname $(ASSEMBLY))
	$(ASSEMBLY_COMPILER_COMMAND) $(ASSEMBLY_COMPILER_FLAGS) -out:$(ASSEMBLY) -target:$(COMPILE_TARGET) $(build_sources_embed) $(build_resources_embed) $(build_references_ref)
