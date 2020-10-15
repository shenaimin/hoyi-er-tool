//
//  <%%# e.ClassName.ToParscal() #%%>.m
//  MeetDragonAide
//
//  Created by Ellen on 15/9/22.
//  Copyright (c) 2015年 kuaifish.com. All rights reserved.
//

#import "<%%# e.ClassName.ToParscal() #%%>.h"

#import "REPModel.h"

@implementation <%%# e.ClassName.ToParscal() #%%>




#pragma mark - 动态方法

/**
 *  初始化  <%%# e.EntityName #%%>
 *
 <%%# [Fields[Inner,1,Last(1)]={
 *  @param name <%#= t.ColumnName #%> <%#= t.Comment #%>  }] #%%>
 */
-(<%%# e.ClassName.ToParscal() #%%> *)initWith<%%# [Fields[Inner,1,Last(0)]={<%#= t.ColumnName #%>:(NSString *)<%#= t.ColumnName #%> }] #%%>{
   
    if(self == [super init]){
        <%%# [Fields[Inner,1,Last(0)]={self.<%#= t.ColumnName #%> = <%#= t.ColumnName #%>;
        }] #%%>
    }
    return self;
}


/**
 *  使用字典初始化  <%%# e.EntityName #%%>对象
 *
 *  @param dic <%%# e.EntityName #%%>  数据
 *
 *  @return <%%# e.EntityName #%%>  对象
 */
-(<%%# e.ClassName.ToParscal() #%%> *)initWithDictionary:(NSDictionary *)dic{
    if(self = [super init]){
        [self setValuesForKeysWithDictionary:dic];
    }
    return self;
}

/**
 *  使用对象初始化  <%%# e.EntityName #%%>  对象
 *
 *  @param dic <%%# e.EntityName #%%>   数据
 *
 *  @return <%%# e.EntityName #%%>   对象
 */
-(<%%# e.ClassName.ToParscal() #%%> *)initWithObject:(NSObject *)object{
    if (object != nil) {
        if ([object isKindOfClass:[REPModel class]]) {  // 如果是REPModel
            
            REPModel *model = (REPModel*)object;
            NSDictionary *dicts = (NSDictionary *)model.data ;
            [self TransFromDictionary:dicts];
            
            return self;
        }
    }
    return nil;
}


/**
 *  初始化  <%%# e.EntityName #%%>
 *
 <%%# [Fields[Inner,1,Last(1)]={
 *  @param name <%#= t.ColumnName #%> <%#= t.Comment #%> }] #%%>
 */
+(<%%# e.ClassName.ToParscal() #%%> *)initWith<%%# [Fields[Inner,1,Last(0)]={<%#= t.ColumnName #%>:(NSString *)<%#= t.ColumnName #%> }] #%%>{
    <%%# e.ClassName.ToParscal() #%%> *<%%# e.ClassName.ToCamel() #%%> = [[<%%# e.ClassName.ToParscal() #%%> alloc] initWith<%%# [Fields[Inner,1,Last(0)]={<%#= t.ColumnName #%>:<%#= t.ColumnName #%> }] #%%>];
    return <%%# e.ClassName.ToCamel() #%%>;
}


-(void)TransFromDictionary:(NSDictionary*)dict{
 <%%# [Fields[Inner,0,Last(0)]={
     self.<%#= t.ColumnName #%> = dict[@"<%#= t.ColumnName #%>"]; }] #%%>
    
}






@end
