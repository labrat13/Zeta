﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tasks.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.3.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string AutoStartStorage {
            get {
                return ((string)(this["AutoStartStorage"]));
            }
            set {
                this["AutoStartStorage"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("400, 400")]
        public global::System.Drawing.Size SelectElementFormSize {
            get {
                return ((global::System.Drawing.Size)(this["SelectElementFormSize"]));
            }
            set {
                this["SelectElementFormSize"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("100, 100")]
        public global::System.Drawing.Point SelectElementFormPosition {
            get {
                return ((global::System.Drawing.Point)(this["SelectElementFormPosition"]));
            }
            set {
                this["SelectElementFormPosition"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("800, 600")]
        public global::System.Drawing.Size MainFormSize {
            get {
                return ((global::System.Drawing.Size)(this["MainFormSize"]));
            }
            set {
                this["MainFormSize"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("100, 100")]
        public global::System.Drawing.Point MainFormPosition {
            get {
                return ((global::System.Drawing.Point)(this["MainFormPosition"]));
            }
            set {
                this["MainFormPosition"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Категория")]
        public string TemplateCategoryTitle {
            get {
                return ((string)(this["TemplateCategoryTitle"]));
            }
            set {
                this["TemplateCategoryTitle"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Кратко описать категорию")]
        public string TemplateCategoryDescription {
            get {
                return ((string)(this["TemplateCategoryDescription"]));
            }
            set {
                this["TemplateCategoryDescription"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Описание и заметки по этой категории:\r\n\r\n\r\n")]
        public string TemplateCategoryRemarks {
            get {
                return ((string)(this["TemplateCategoryRemarks"]));
            }
            set {
                this["TemplateCategoryRemarks"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Заметка")]
        public string TemplateNoteTitle {
            get {
                return ((string)(this["TemplateNoteTitle"]));
            }
            set {
                this["TemplateNoteTitle"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Кратко описать заметку")]
        public string TemplateNoteDescription {
            get {
                return ((string)(this["TemplateNoteDescription"]));
            }
            set {
                this["TemplateNoteDescription"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"Добавить содержание заметки:
- Заметки предлагается использовать для описания некоторого правила при работе в данной теме.
Или другой подобной информации. Они подобны краткой инструкции Работать здесь, но полезно будет указать причину их возникновения или цель, которой они служат.

.")]
        public string TemplateNoteRemarks {
            get {
                return ((string)(this["TemplateNoteRemarks"]));
            }
            set {
                this["TemplateNoteRemarks"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Задача")]
        public string TemplateTaskTitle {
            get {
                return ((string)(this["TemplateTaskTitle"]));
            }
            set {
                this["TemplateTaskTitle"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Кратко описать задачу")]
        public string TemplateTaskDescription {
            get {
                return ((string)(this["TemplateTaskDescription"]));
            }
            set {
                this["TemplateTaskDescription"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"Описание и замечания по этой задаче:

1. Что собственно требуется сделать?
- todo:  Не забудьте добавить требуемые результаты задачи  в  поле списка целей задачи.

2. Каким образом это можно сделать?
- перечислите тут известные способы выполнения задачи.

3. Какие потребуются ресурсы?
- перечислите необходимые ресурсы  для каждого из выбранных способов выполнения задачи.
- для добычи каждого ресурса следует создать собственную подзадачу к этой задаче.

4. Какие еще причины мешают вам просто сделать уже эту работу? 
- Опишите здесь текущее состояние работы по задаче, проблемы и полезные замечания.

5. Ход выполнения работы
- можно ли описать работу над задачей  как последовательность действий?
Это пригодилось бы при выполнении подобной задачи.
- если да, создайте под-задачу для составления такого плана действий.


  
")]
        public string TemplateTaskRemarks {
            get {
                return ((string)(this["TemplateTaskRemarks"]));
            }
            set {
                this["TemplateTaskRemarks"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Перечислите здесь результаты задачи как цели, которые необходимо достичь, и опиши" +
            "те их текущее состояние. \r\nПосле завершения задачи отметьте состояние каждой из " +
            "перечисленных тут целей.\r\n\r\nЦели данной задачи:\r\n1. \r\n2. \r\n3. \r\n\r\n")]
        public string TemplateTaskResults {
            get {
                return ((string)(this["TemplateTaskResults"]));
            }
            set {
                this["TemplateTaskResults"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Тег")]
        public string TemplateTagTitle {
            get {
                return ((string)(this["TemplateTagTitle"]));
            }
            set {
                this["TemplateTagTitle"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Кратко описать тег")]
        public string TemplateTagDescription {
            get {
                return ((string)(this["TemplateTagDescription"]));
            }
            set {
                this["TemplateTagDescription"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Описания и замечания по этому тегу:\r\n\r\n- Какие сущности  должен описывать этот те" +
            "г?\r\n\r\n- Каковы критерии присвоения некоторой сущности именно этого тега?")]
        public string TemplateTagRemarks {
            get {
                return ((string)(this["TemplateTagRemarks"]));
            }
            set {
                this["TemplateTagRemarks"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("100, 100")]
        public global::System.Drawing.Point CategoryPropFormPosition {
            get {
                return ((global::System.Drawing.Point)(this["CategoryPropFormPosition"]));
            }
            set {
                this["CategoryPropFormPosition"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("100, 100")]
        public global::System.Drawing.Size CategoryPropFormSize {
            get {
                return ((global::System.Drawing.Size)(this["CategoryPropFormSize"]));
            }
            set {
                this["CategoryPropFormSize"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("100, 100")]
        public global::System.Drawing.Point NotePropFormPosition {
            get {
                return ((global::System.Drawing.Point)(this["NotePropFormPosition"]));
            }
            set {
                this["NotePropFormPosition"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("100, 100")]
        public global::System.Drawing.Size NotePropFormSize {
            get {
                return ((global::System.Drawing.Size)(this["NotePropFormSize"]));
            }
            set {
                this["NotePropFormSize"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("100, 100")]
        public global::System.Drawing.Point TaskPropFormPosition {
            get {
                return ((global::System.Drawing.Point)(this["TaskPropFormPosition"]));
            }
            set {
                this["TaskPropFormPosition"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("100, 100")]
        public global::System.Drawing.Size TaskPropFormSize {
            get {
                return ((global::System.Drawing.Size)(this["TaskPropFormSize"]));
            }
            set {
                this["TaskPropFormSize"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("100, 100")]
        public global::System.Drawing.Point TagPropFormPosition {
            get {
                return ((global::System.Drawing.Point)(this["TagPropFormPosition"]));
            }
            set {
                this["TagPropFormPosition"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("100, 100")]
        public global::System.Drawing.Size TagPropFormSize {
            get {
                return ((global::System.Drawing.Size)(this["TagPropFormSize"]));
            }
            set {
                this["TagPropFormSize"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("100, 100")]
        public global::System.Drawing.Point TrashcanPropFormPosition {
            get {
                return ((global::System.Drawing.Point)(this["TrashcanPropFormPosition"]));
            }
            set {
                this["TrashcanPropFormPosition"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("100, 100")]
        public global::System.Drawing.Size TrashcanPropFormSize {
            get {
                return ((global::System.Drawing.Size)(this["TrashcanPropFormSize"]));
            }
            set {
                this["TrashcanPropFormSize"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("100, 100")]
        public global::System.Drawing.Size StorageCreateFormSize {
            get {
                return ((global::System.Drawing.Size)(this["StorageCreateFormSize"]));
            }
            set {
                this["StorageCreateFormSize"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("100, 100")]
        public global::System.Drawing.Point StorageCreateFormPosition {
            get {
                return ((global::System.Drawing.Point)(this["StorageCreateFormPosition"]));
            }
            set {
                this["StorageCreateFormPosition"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("100, 100")]
        public global::System.Drawing.Size StorageShortInfoFormSize {
            get {
                return ((global::System.Drawing.Size)(this["StorageShortInfoFormSize"]));
            }
            set {
                this["StorageShortInfoFormSize"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("100, 100")]
        public global::System.Drawing.Point StorageShortInfoFormPosition {
            get {
                return ((global::System.Drawing.Point)(this["StorageShortInfoFormPosition"]));
            }
            set {
                this["StorageShortInfoFormPosition"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("100, 100")]
        public global::System.Drawing.Size SettingTemplatesFormSize {
            get {
                return ((global::System.Drawing.Size)(this["SettingTemplatesFormSize"]));
            }
            set {
                this["SettingTemplatesFormSize"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("100, 100")]
        public global::System.Drawing.Point SettingTemplatesFormPosition {
            get {
                return ((global::System.Drawing.Point)(this["SettingTemplatesFormPosition"]));
            }
            set {
                this["SettingTemplatesFormPosition"] = value;
            }
        }
    }
}
