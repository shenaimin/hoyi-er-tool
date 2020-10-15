//
//  <%%# e.ClassName.ToParscal() #%%>.h
//  MeetDragonAide
//
//  Created by Ellen on 15/9/22.
//  Copyright (c) 2015年 kuaifish.com. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface <%%# e.ClassName.ToParscal() #%%> : NSObject


#define <%%# e.ClassName.ToParscal() #%%>_TABLENAME @"<%%# e.ClassName.ToParscal() #%%>"

<%%# [Fields[x]={
#define <%#= e.ClassName.ToParscal() #%>_<%#= t.ColumnName #%> @"<%#= t.ColumnName #%>"
}] #%%>


<%%# [Fields[x]={
#pragma mark <%#= t.Comment #%>
@property (nonatomic,strong) NSString *<%#= t.ColumnName #%>;
}] #%%>   


#pragma mark - 动态方法

/**
 *  初始化  <%%# e.EntityName #%%>
 *
 <%%# [Fields[Inner,1,Last(1)]={
 *  @param name <%#= t.ColumnName #%>  <%#= t.Comment #%>  }] #%%>
 */
-(<%%# e.ClassName.ToParscal() #%%> *)initWith<%%# [Fields[Inner,1,Last(0)]={<%#= t.ColumnName #%>:(NSString *)<%#= t.ColumnName #%> }] #%%>;


/**
 *  使用字典初始化  <%%# e.EntityName #%%>  对象
 *
 *  @param dic <%%# e.EntityName #%%>  数据
 *
 *  @return <%%# e.EntityName #%%>  对象
 */
-(<%%# e.ClassName.ToParscal() #%%> *)initWithDictionary:(NSDictionary *)dic;

/**
 *  使用对象初始化  <%%# e.EntityName #%%>  对象
 *
 *  @param dic <%%# e.EntityName #%%>   数据
 *
 *  @return <%%# e.EntityName #%%>   对象
 */
-(<%%# e.ClassName.ToParscal() #%%> *)initWithObject:(NSObject *)object;

/**
 *  初始化  <%%# e.EntityName #%%>
 *
 <%%# [Fields[Inner,1,Last(1)]={
 *  @param name <%#= t.ColumnName #%>  <%#= t.Comment #%>  }] #%%>
 */
+(<%%# e.ClassName.ToParscal() #%%> *)initWith<%%# [Fields[Inner,1,Last(0)]={<%#= t.ColumnName #%>:(NSString *)<%#= t.ColumnName #%> }] #%%>;


-(void)TransFromDictionary:(NSDictionary*)dict;

@end
