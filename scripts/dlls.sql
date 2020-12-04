ALTER TABLE tb_product

ADD COLUMN waste decimal(18,3) AFTER kcalTotal,

ADD COLUMN costbyRecipeMeasureUnit decimal(18,3) AFTER waste ,

ADD COLUMN RecipeMeasureUnitId int(11) AFTER costbyRecipeMeasureUnit;


ALTER TABLE tb_measuredunit ADD COLUMN baseMeasuredUnitId int(11) AFTER isEnabled;

ALTER TABLE `tb_measuredunit` 
CHANGE COLUMN `conversionFactor` `conversionFactor` DECIMAL(18,2) NULL DEFAULT NULL ;


